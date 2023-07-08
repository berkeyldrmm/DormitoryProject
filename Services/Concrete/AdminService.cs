using AutoMapper;
using DataAccess.Abstract;
using DTOs.AuthenticationDTOs;
using DTOs.UpdateDTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public AdminService(IUserRepository userRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> CreateAdmin(AdminDTO adminDto)
        {
            AppUser user = _mapper.Map<AppUser>(adminDto);
            user.UserName = adminDto.Email;
            user.Date = DateTime.Now;
            var result = await _userManager.CreateAsync(user, adminDto.Password);
            if (result.Succeeded)
            {
                var result2 = await _userManager.AddToRoleAsync(user, "Admin");
                return result2.Succeeded;
            }
            return false;
        }

        public async Task<bool> DeleteUserAsync(AppUser entity)
        {
            var result = await _userManager.DeleteAsync(entity);
            return result.Succeeded;
        }

        public IEnumerable<AppUser> GetAdmins()
        {
            return _userRepository.GetUsersByRole("Admin").ToList();
        }

        public AppUser UpdateUser(AppUser admin, AdminUpdateDTO adminDTO)
        {
            admin.Name = adminDTO.Name;
            admin.Surname = adminDTO.Surname;
            admin.PhoneNumber = adminDTO.PhoneNumber;
            admin.Email = adminDTO.Email;
            admin.UserName = adminDTO.Email;
            return admin;
        }
    }
}
