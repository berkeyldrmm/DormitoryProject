using DTOs.UpdateDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationRules
{
    public class StudentUpdateDTOValidation : AbstractValidator<StudentUpdateDTO>
    {
        public StudentUpdateDTOValidation()
        {
            RuleFor(su => su.Name).NotEmpty().WithMessage("Lütfen öğrencinin adını giriniz");
            RuleFor(su => su.Surname).NotEmpty().WithMessage("Lütfen öğrencinin soyadını giriniz");
            RuleFor(su => su.Email).NotEmpty().WithMessage("Lütfen öğrencinin mail bilgisini giriniz");
            RuleFor(su => su.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi girin.");
            RuleFor(su => su.PhoneNumber).NotEmpty().WithMessage("Lütfen telefon numarasını giriniz");
            RuleFor(su => su.RoomId).NotEmpty().WithMessage("Lütfen öğrencinin kalacağı oda numarasını giriniz");
            RuleFor(su => su.School).NotEmpty().WithMessage("Lütfen öğrencinin öğrenim gördüğü okulun adını giriniz");
        }
    }
}
