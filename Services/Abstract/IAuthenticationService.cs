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
        Task<SignInResult> LoginAsync(LoginDTO loginDTO);
        TokenDTO CreateToken(IConfiguration _configuration, int minute);
    }
}
