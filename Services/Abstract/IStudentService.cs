﻿using DTOs.AuthenticationDTOs;
using DTOs.UpdateDTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IStudentService
    {
        public Task<bool> DeleteUserAsync(AppUser entity);
        public IEnumerable<AppUser> GetStudents();
        public Task<bool> CreateStudent(StudentDTO userDto);
        public AppUser UpdateUser(AppUser student, StudentUpdateDTO studentDTO);
        public IEnumerable<AppUser> GetStudentsWithSuggestions();
        public AppUser GetStudentWithSuggestions(int id);
        public IEnumerable<AppUser> GetStudentsWithPermissions();
        public AppUser GetStudentWithPermissions(int id);
        public IEnumerable<EventParticipant> GetStudentsOfEvent(int id);
        public void AddStudentToEvent(Event _event, EventParticipant eventParticipant);
    }
}
