using DTOs.AuthenticationDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationRules
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator() { 
            RuleFor(l=>l.Username).NotEmpty().WithMessage("Lütfen kullanıcı adınızı giriniz");
            RuleFor(l=>l.Password).NotEmpty().WithMessage("Lütfen şifrenizi giriniz");
        }
    }
}
