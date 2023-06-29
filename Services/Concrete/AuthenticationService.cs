using DTOs.AuthenticationDTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<AppUser> _signInManager;
        public AuthenticationService(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public TokenDTO CreateToken(IConfiguration _configuration, int minute)
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
                signingCredentials: securityCredentials
            );
            //Token oluşturucu sınıfından bir örnek oluşturulur.
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            //Oluşturduğumuz token'ı döndürürüz.
            return token;
        }

        public async Task<SignInResult> LoginAsync(LoginDTO loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Username, loginDTO.Password, false, true);
            return result;
        }
    }
}
