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
    [Authorize(Policy = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly RoleManager<AppRole> _roleManager;
        public RoleController(IRoleService roleService, RoleManager<AppRole> roleManager)
        {
            _roleService = roleService;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            try
            {
                var roles = _roleService.GetRoles();
                return Ok(roles);
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRoleByIdAsync(int id)
        {
            try
            {
                var user = await _roleService.GetOneRole(id);
                if (user is null)
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
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (ModelState.IsValid)
            {
                var role = new AppRole()
                {
                    Name = roleName,
                };
                var result = await _roleService.CreateRoleAsync(role);
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
        public async Task<IActionResult> UpdateRole(int id, string roleName)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            role.Name=roleName;
            var result = await _roleManager.UpdateAsync(role);
            await _roleManager.UpdateNormalizedRoleNameAsync(role);
            if (result.Succeeded)
            {
                return Ok(role);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoleByIdAsync(int id)
        {
            try
            {
                var user = await _roleService.GetOneRole(id);
                var result = await _roleService.DeleteRoleAsync(user);
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
