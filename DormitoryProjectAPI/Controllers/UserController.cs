using AutoMapper;
using DTOs.AuthenticationDTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace DormitoryProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        public UserController(IUserService userService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _userService.GetStudents();
                return Ok(students);
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            try
            {
                var user = await _userService.GetOne(id);
                if(user is null)
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
        public async Task<IActionResult> AddStudent(UserDTO userDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateStudent(userDto);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
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
        public async Task<IActionResult> DeleteStudentByIdAsync(int id)
        {
            try
            {
                var user = await _userService.GetOne(id);
                var result = await _userService.DeleteUserAsync(user);
                if (result)
                {
                    return NoContent();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
        }
    }
}
