using AutoMapper;
using DataAccess.Abstract;
using DataAccess.Repositories;
using DTOs.AuthenticationDTOs;
using DTOs.UpdateDTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public StudentService(IUserRepository userRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> CreateStudent(StudentDTO userDto)
        {
            AppUser user = _mapper.Map<AppUser>(userDto);
            user.UserName = userDto.Email;
            user.Date = DateTime.Now;
            user.PermissionRights = 60;
            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (result.Succeeded)
            {
                var result2 = await _userManager.AddToRoleAsync(user, "Student");
                return result2.Succeeded;
            }
            return false;
        }

        public async Task<bool> DeleteUserAsync(AppUser entity)
        {
            var result = await _userManager.DeleteAsync(entity);
            return result.Succeeded;
        }

        public IEnumerable<AppUser> GetStudents()
        {
            return _userRepository.GetUsersByRole("Student").ToList();
        }

        public AppUser UpdateUser(AppUser student, StudentUpdateDTO studentDTO)
        {
            student.Name = studentDTO.Name;
            student.Surname = studentDTO.Surname;
            student.PhoneNumber = studentDTO.PhoneNumber;
            student.Email = studentDTO.Email;
            student.UserName = studentDTO.Email;
            student.RoomId = studentDTO.RoomId;
            student.School = studentDTO.School;
            student.Department = studentDTO.Department;
            student.ParentName_Surname = studentDTO.ParentName_Surname;
            student.ParentPhoneNumber = studentDTO.ParentPhoneNumber;
            return student;
        }

        public async Task AddSuggestionsToStudentAsync(Suggestion_Complaint suggestion)
        {
            AppUser user = await _userManager.FindByIdAsync(suggestion.StudentId.ToString());
            user.Suggestions_Complaints.Add(suggestion);
            await _userManager.UpdateAsync(user);
        }

        public IEnumerable<AppUser> GetStudentsWithEvents()
        {
            return _userRepository.GetUsersWithEvents().ToList();
        }
        public IEnumerable<AppUser> GetStudentWithEvents(int id)
        {
            _userManager.FindByIdAsync(id.ToString());
            return _userRepository.GetUsersWithEvents().Where(s=>s.Id==id).ToList();
        }
    }
}
