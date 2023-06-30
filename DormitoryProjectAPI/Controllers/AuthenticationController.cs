using DTOs.AuthenticationDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Abstract;

namespace DormitoryProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO, string role)
        {
            if(ModelState.IsValid)
            {
                var result = await _authenticationService.LoginAsync(loginDTO, role);
                if (result)
                {
                    TokenDTO token=_authenticationService.CreateToken(_configuration, 10);
                    return Ok(token);
                }
                else
                {
                    throw new Exception("Kullanıcı adı veya şifre hatalı.");
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _authenticationService.LogoutAsync();
                return Ok();
            }
            catch (Exception)
            {
                throw new Exception("Bilinmeyen bir hata oluştu.");
            }
            
        }
    }
}
