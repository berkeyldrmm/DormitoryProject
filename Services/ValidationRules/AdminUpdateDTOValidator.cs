using DTOs.UpdateDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationRules
{
    public class AdminUpdateDTOValidator : AbstractValidator<AdminUpdateDTO>
    {
        public AdminUpdateDTOValidator()
        {
            RuleFor(au => au.Name).NotEmpty().WithMessage("Lütfen adminin adını girin.");
            RuleFor(au => au.Surname).NotEmpty().WithMessage("Lütfen adminin soyadını girin.");
            RuleFor(au => au.Email).NotEmpty().WithMessage("Lütfen adminin mailini girin.");
            RuleFor(au => au.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi girin.");
            RuleFor(au => au.PhoneNumber).NotEmpty().WithMessage("Lütfen adminin telefon numarasını girin.");
        }
    }
}
