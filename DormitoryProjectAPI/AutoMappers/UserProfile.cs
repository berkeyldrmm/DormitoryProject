using AutoMapper;
using DTOs.AuthenticationDTOs;
using Entities.Concrete;

namespace DormitoryProjectAPI.AutoMappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, AppUser>();
        }
    }
}
