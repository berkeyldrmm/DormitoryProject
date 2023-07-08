using DTOs.AuthenticationDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationRules
{
    public class AdminDTOValidator : AbstractValidator<AdminDTO>
    {
        public AdminDTOValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Lütfen adminin adını girin.");
            RuleFor(a => a.Surname).NotEmpty().WithMessage("Lütfen adminin soyadını girin.");
            RuleFor(a => a.Email).NotEmpty().WithMessage("Lütfen adminin mailini girin.");
            RuleFor(a => a.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi girin.");
            RuleFor(a => a.PhoneNumber).NotEmpty().WithMessage("Lütfen adminin telefon numarasını girin.");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Lütfen admin için bir şifre belirleyin.");
        }
    }
}
