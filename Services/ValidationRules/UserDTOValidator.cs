using DTOs.AuthenticationDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationRules
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Lütfen öğrencinin adını giriniz");
            RuleFor(u => u.Surname).NotEmpty().WithMessage("Lütfen öğrencinin soyadını giriniz");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Lütfen öğrencinin mail bilgisini giriniz");
            RuleFor(u => u.PhoneNumber).NotEmpty().WithMessage("Lütfen telefon numarasını giriniz");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Lütfen öğrenci için bir şifre belirleyiniz");
            RuleFor(u => u.RoomId).NotEmpty().WithMessage("Lütfen öğrencinin kalacağı oda numarasını giriniz");
            RuleFor(u => u.School).NotEmpty().WithMessage("Lütfen öğrencinin öğrenim gördüğü okulun adını giriniz");
        }
    }
}
