using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }
        public IQueryable<AppUser> GetStudents()
        {
            var students = (from users in Entity
                            join userroles in _context.UserRoles on users.Id equals userroles.UserId
                            join roles in _context.Roles on userroles.RoleId equals roles.Id
                            where roles.Name=="Ogrenci"
                            select users).AsQueryable();
            return students;
        }
    }
}
