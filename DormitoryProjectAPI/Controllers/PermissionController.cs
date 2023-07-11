using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.Concrete;

namespace DormitoryProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly IStudentService _studentService;
        private readonly IUnitOfWork _unitOfWork;
        public PermissionController(IPermissionService permissionService, IUnitOfWork unitOfWork, IStudentService studentService)
        {
            _permissionService = permissionService;
            _unitOfWork = unitOfWork;
            _studentService = studentService;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult GetPermissions()
        {
            try
            {
                var suggesitons = _permissionService.GetAll();
                return Ok(suggesitons);
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetPermissionByIdAsync(int id)
        {
            try
            {
                var user = await _permissionService.GetOne(id);
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

        [Route("getpermissionsofstudent/{id:int}")]
        [HttpGet]
        [Authorize]
        public IActionResult GetPermissionsOfStudent(int id)
        {
            try
            {
                var permissions = _permissionService.GetPermissionsOfStudent(id);
                if (permissions is null)
                {
                    return NotFound();
                }
                return Ok(permissions);
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPermission(Permission permission)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _permissionService.Create(permission);
                    if (result)
                    {
                        var result3=await _permissionService.AddPermissionsToStudentAsync(permission);
                        if (result3)
                        {
                            var result4 = await _unitOfWork.Save();
                            return Ok();
                        }
                        var result2 = _permissionService.DeleteAsync(permission);
                        throw new Exception("Bir hata oluştu.");
                    }
                    else
                    {
                        throw new Exception("Bir hata oluştu.");
                    }
                }
                return BadRequest();
            }
            catch (Exception err)
            {
                if (err as DirectoryNotFoundException is not null)
                {
                    var result2=_permissionService.DeleteAsync(permission);
                    if(!result2)
                    {
                        throw new Exception("Bir hata oluştu.");
                    }
                    return NotFound();
                }
                throw err;
            }
            
        }

        [HttpDelete]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteSuggestionByIdAsync(int id)
        {
            try
            {
                var suggestion = await _permissionService.GetOne(id);
                if (suggestion is not null)
                {
                    var result = _permissionService.DeleteAsync(suggestion);
                    if (result)
                    {
                        await _unitOfWork.Save();
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
