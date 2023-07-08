using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
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
        public IQueryable<AppUser> GetUsersByRole(string role)
        {
            IQueryable<AppUser> linq;
            if (role == "Admin")
            {
                linq = (from users in Entity
                            join userroles in _context.UserRoles on users.Id equals userroles.UserId
                            join roles in _context.Roles on userroles.RoleId equals roles.Id
                            where roles.Name == role
                            select new AppUser()
                            {
                                Id= users.Id,
                                Name= users.Name,
                                Surname= users.Surname,
                                Email= users.Email,
                                PhoneNumber= users.PhoneNumber
                            });
            }
            else
            {
                linq = (from users in Entity
                            join userroles in _context.UserRoles on users.Id equals userroles.UserId
                            join roles in _context.Roles on userroles.RoleId equals roles.Id
                            where roles.Name == role
                            select users);
            }
            
            return linq.AsQueryable();
        }
        public IQueryable<AppUser> GetUsersWithSuggestions()
        {
            return GetUsersByRole("Student").Include(s=>s.Suggestions_Complaints).AsQueryable();
        }
    }
}
