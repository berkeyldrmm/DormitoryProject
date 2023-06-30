using DTOs.AuthenticationDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(LoginDTO loginDTO, string role);
        public Task LogoutAsync();
        TokenDTO CreateToken(IConfiguration _configuration, int minute);
    }
}
