using AutoMapper;
using DataAccess.Abstract;
using DTOs.AuthenticationDTOs;
using DTOs.UpdateDTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.Concrete;

namespace DormitoryProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRoomService _roomService;
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IStudentService userService, UserManager<AppUser> userManager, IRoomService roomService, IUnitOfWork unitOfWork)
        {
            _studentService = userService;
            _userManager = userManager;
            _roomService = roomService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _studentService.GetStudents();
                return Ok(students);
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if(user is null || !(await _userManager.IsInRoleAsync(user, "Student")))
                {
                    return BadRequest();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddStudent(StudentDTO userDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var room = await _roomService.GetOne(userDto.RoomId);
                    if (room.Availability)
                    {
                        var result = await _studentService.CreateStudent(userDto);
                        if (result)
                        {
                            _roomService.IncreaseandCheckNumberofStudent(room);
                            _roomService.AddStudentToRoom(room, await _userManager.FindByEmailAsync(userDto.Email));
                            var result2 = _roomService.Update(room);
                            var result3 = await _unitOfWork.Save();
                            if (result2 && result3 == 1)
                            {
                                return Ok(userDto);
                            }
                            else
                            {
                                var result4 = await _userManager.DeleteAsync(await _userManager.FindByNameAsync(userDto.Name));
                                if (result4.Succeeded)
                                {
                                    throw new Exception("Öğrenci kaydı oluşturulamadı. Bir hata oluştu.");
                                }
                                throw new Exception("Öğrenci kaydı oluşturuldu fakat odası atanamadı. Kaydı silip tekrar kayıt etmeyi ya da kaydı güncellemyi deneyin.");
                            }
                        }
                        else
                        {
                            throw new Exception("Öğrenci kaydı oluşturulamadı. Bir hata oluştu.");
                        }
                    }
                    else
                    {
                        throw new Exception("Odada yer yok.");
                    }
                }
                return BadRequest();
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
            
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateStudent(int id, StudentUpdateDTO studentDto)
        {
            try
            {
                var student = await _userManager.FindByIdAsync(id.ToString());
                if(student is null)
                {
                    return NotFound();
                }
                var room = await _roomService.GetOne((int)student.RoomId);
                _roomService.DecreaseNumberofStudent(room);
                var result4 = _roomService.Update(room);
                if (!result4)
                {
                    throw new Exception("Bir hata oluştu.");
                }
                var user = _studentService.UpdateUser(student, studentDto);
                if(user is null) {
                    return NotFound();
                }
                var newroom = await _roomService.GetOne((int)user.RoomId);
                if (newroom.Availability)
                {
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        _roomService.IncreaseandCheckNumberofStudent(newroom);
                        var result2 = _roomService.Update(newroom);
                        var result3 = await _unitOfWork.Save();
                        if (result2 && result3 == 1)
                        {
                            return Ok(user);
                        }
                        else
                        {
                            throw new Exception("Bir hata oluştu.");
                        }
                    }
                    else
                    {
                        throw new Exception("Bir hata oluştu.");
                    }
                }
                else
                {
                    throw new Exception("Odada yer yok.");
                }
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
            
        }

        [HttpDelete]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteStudentByIdAsync(int id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if ((await _userManager.IsInRoleAsync(user, "Student")) && user is not null)
                {
                    var result = await _studentService.DeleteUserAsync(user);
                    if (result)
                    {
                        var room = await _roomService.GetOne((int)user.RoomId);
                        _roomService.DecreaseNumberofStudent(room);
                        var result2 = _roomService.Update(room);
                        var result3 = await _unitOfWork.Save();
                        if (result2 && result3 == 1)
                        {
                            return NoContent();
                        }
                        else
                        {
                            throw new Exception("Bir hata oluştu.");
                        }
                    }
                }
                return BadRequest();
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        [Route("getstudentswithsuggestions")]
        [HttpGet]
        public IActionResult GetStudentsWithSuggestions()
        {
            var students=_studentService.GetStudentsWithSuggestions();
            return Ok(students);
        }

        [Route("getstudentwithsuggestions/{StudentId:int}")]
        [HttpGet]
        public IActionResult GetStudentWithSuggestions(int StudentId)
        {
            var student = _studentService.GetStudentWithSuggestions(StudentId);
            return Ok(student);
        }
    }
}
