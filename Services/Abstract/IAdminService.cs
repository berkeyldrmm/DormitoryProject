using DTOs.AuthenticationDTOs;
using DTOs.UpdateDTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IAdminService
    {
        public Task<bool> CreateAdmin(AdminDTO adminDto);
        public Task<bool> DeleteUserAsync(AppUser entity);
        public IEnumerable<AppUser> GetAdmins();
        public AppUser UpdateUser(AppUser admin, AdminUpdateDTO adminDTO);
    }
}
