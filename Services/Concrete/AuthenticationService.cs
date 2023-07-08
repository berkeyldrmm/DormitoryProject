using DTOs.AuthenticationDTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public AuthenticationService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public TokenDTO CreateToken(IConfiguration _configuration, int minute, string role, string username)
        {
            TokenDTO token = new();
            //SecurityKey'in simetriğini alırız.
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            //Şifrelenmiş kimlik oluştururuz.
            SigningCredentials securityCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //Oluşturulacak token ayarlarını bildiririz.
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: securityCredentials,
                claims:new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }
            );
            //Token oluşturucu sınıfından bir örnek oluşturulur.
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            //Oluşturduğumuz token'ı döndürürüz.
            return token;
        }

        public async Task<bool> LoginAsync(LoginDTO loginDTO, string role)
        {
            var user=await _userManager.FindByNameAsync(loginDTO.Username);
            if(await _userManager.IsInRoleAsync(user, role))
            {
                var result = await _signInManager.PasswordSignInAsync(loginDTO.Username, loginDTO.Password, false, true);
                return result.Succeeded;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO, AppUser user)
        {
            IdentityResult result=await _userManager.ChangePasswordAsync(user, changePasswordDTO.OldPassword, changePasswordDTO.NewPassword);
            return result.Succeeded;
        }
    }
}
