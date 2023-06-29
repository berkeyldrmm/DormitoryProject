using AutoMapper;
using DTOs.AuthenticationDTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace DormitoryProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task <IActionResult> GetStudents()
        {
            var users = _userService.GetAll();
            var students = new List<AppUser>();
            foreach (var user in users)
            {
                var result=await _userManager.IsInRoleAsync(user, "Öğrenci");
                if (result)
                {
                    students.Add(user);
                }
            }
            return Ok(students);
        }

        [HttpGet("id")]
        public IActionResult GetStudentById(int id)
        {
            var user = _userService.GetOne(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(UserDTO userDto)
        {
            if(ModelState.IsValid)
            {
                AppUser user = _mapper.Map<AppUser>(userDto);
                user.UserName = userDto.Email;
                user.Date= DateTime.Now;
                user.PermissionRights = 60;
                var result = await _userManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                {
                    var result2=await _userManager.AddToRoleAsync(user, "Öğrenci");
                    if (result2.Succeeded)
                    {
                        return Ok(user);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bir hata meydana geldi.");
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateStudent(AppUser user)
        {
            var result=_userService.Update(user);
            if (result)
            {
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteStudent(AppUser user)
        {
            var result = _userService.Delete(user);
            if (result)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
