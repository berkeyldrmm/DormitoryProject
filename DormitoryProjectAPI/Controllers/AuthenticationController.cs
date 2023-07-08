using DTOs.AuthenticationDTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DormitoryProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IAuthenticationService authenticationService, IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO, string role)
        {
            if(ModelState.IsValid)
            {
                var result = await _authenticationService.LoginAsync(loginDTO, role);
                if (result)
                {
                    TokenDTO token=_authenticationService.CreateToken(_configuration, 100, role, loginDTO.Username);
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
        [Route("changepassword")]
        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO)
        {
            if (HttpContext.Request.Headers.TryGetValue("Authorization", out var token))
            {
                var accessToken = token[0].Split(' ')[1];
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(accessToken);

                var username = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                AppUser user = await _userManager.FindByNameAsync(username);
                if (user is null)
                {
                    return NotFound();
                }
                var result = await _authenticationService.ChangePasswordAsync(changePasswordDTO, user);
                if (result)
                {
                    return Ok();
                }
                throw new Exception("Bir hata oluştu.");
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
