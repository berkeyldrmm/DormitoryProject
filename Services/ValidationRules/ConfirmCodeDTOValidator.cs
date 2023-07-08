using FluentValidation;
using IdentityProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationRules
{
    public class ConfirmCodeDTOValidator : AbstractValidator<ConfirmCodeDTO>
    {
        public ConfirmCodeDTOValidator()
        {
            RuleFor(cc => cc.Mail).NotEmpty().WithMessage("Lütfen bir mail adresi giriniz.");
            RuleFor(cc => cc.Mail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
            RuleFor(cc => cc.ConfirmCode).NotEmpty().WithMessage("Lütfen doğrulama kodunu giriniz.");
            RuleFor(cc => cc.ConfirmCode).LessThanOrEqualTo(999999).GreaterThanOrEqualTo(100000).WithMessage("Doğrulama kodunuz 6 basamaklıdır.");
        }
    }
}
