using AutoMapper;
using DTOs.AuthenticationDTOs;
using DTOs.UpdateDTOs;
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
    [Authorize(Policy = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly UserManager<AppUser> _userManager;
        public AdminController(IAdminService adminService, UserManager<AppUser> userManager)
        {
            _adminService = adminService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetAdminsAsync()
        {
            try
            {
                var students = _adminService.GetAdmins();
                return Ok(students);
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAdminByIdAsync(int id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user is null || !(await _userManager.IsInRoleAsync(user,"Admin")))
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
        public async Task<IActionResult> AddAdmin(AdminDTO adminDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.CreateAdmin(adminDto);
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
        public async Task<IActionResult> UpdateAdmin(int id, AdminUpdateDTO adminDto)
        {
            var admin =await _userManager.FindByIdAsync(id.ToString());
            var user=_adminService.UpdateUser(admin, adminDto);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAdminByIdAsync(int id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if ((await _userManager.IsInRoleAsync(user, "Admin")) && user is not null)
                {
                    var result = await _adminService.DeleteUserAsync(user);
                    if (result)
                    {
                        return NoContent();
                    }
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
