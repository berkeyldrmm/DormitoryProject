using AutoMapper;
using DataAccess.Abstract;
using DataAccess.Repositories;
using DTOs.AuthenticationDTOs;
using DTOs.UpdateDTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
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
        private readonly IEventParticipantRepository _eventParticipantRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public StudentService(IUserRepository userRepository, IMapper mapper, UserManager<AppUser> userManager, IEventParticipantRepository eventParticipantRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _eventParticipantRepository = eventParticipantRepository;
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

        
        public IEnumerable<AppUser> GetStudentsWithSuggestions()
        {
            return _userRepository.GetUsersWithSuggestions().ToList();
        }
        public AppUser GetStudentWithSuggestions(int id)
        {
            return _userRepository.GetUsersWithSuggestions().SingleOrDefault(s => s.Id == id);
        }
        

        public IEnumerable<AppUser> GetStudentsWithPermissions()
        {
            return _userRepository.GetStudentsWithPermissions().ToList();
        }
        public AppUser GetStudentWithPermissions(int id)
        {
            return _userRepository.GetStudentsWithPermissions().SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<EventParticipant> GetStudentsOfEvent(int id)
        {
            return _eventParticipantRepository.GetStudentsOfEvent(id).ToList();
        }

        public void AddStudentToEvent(Event _event, EventParticipant eventParticipant)
        {
            var b = _event.Students.Contains(eventParticipant);
            if (!_event.Students.Contains(eventParticipant))
            {
                _event.Students.Add(eventParticipant);
            }
                
            throw new Exception("Bu öğrenci, bu etkinliğe zaten kayıtlı.");
        }
    }
}
