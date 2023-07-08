using AutoMapper;
using DTOs.AuthenticationDTOs;
using DTOs.UpdateDTOs;
using Entities.Concrete;

namespace DormitoryProjectAPI.AutoMappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<StudentDTO, AppUser>();
            CreateMap<AdminDTO, AppUser>();
            //CreateMap<StudentUpdateDTO, AppUser>();
        }
    }
}
