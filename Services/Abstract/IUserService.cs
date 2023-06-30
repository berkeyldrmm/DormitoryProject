using DTOs.AuthenticationDTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IUserService : IGenericService<AppUser>
    {
        public Task<bool> DeleteUserAsync(AppUser entity);
        public IEnumerable<AppUser> GetStudents();
        public Task<bool> CreateStudent(UserDTO userDto);
    }
}
