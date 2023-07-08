using DTOs.AuthenticationDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationRules
{
    public class ChangePasswordDTOValidator : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordDTOValidator()
        {
            RuleFor(cp => cp.OldPassword).NotEmpty().WithMessage("Lütfen eski şifrenizi giriniz.");
            RuleFor(cp => cp.NewPassword).NotEmpty().WithMessage("Lütfen yeni bir şifre belirleyiniz.");
            RuleFor(cp => cp.ConfirmNewPassword).NotEmpty().WithMessage("Lütfen yeni şifrenizi tekrar giriniz.");
            RuleFor(cp => cp.ConfirmNewPassword).Equal(cp=>cp.NewPassword).WithMessage("Şifreler uyuşmuyor..");
        }
    }
}
