using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        IQueryable<AppUser> GetUsersByRole(string role);
        public IQueryable<AppUser> GetUsersWithSuggestions();
        public IQueryable<AppUser> GetStudentsWithPermissions();
    }
}
