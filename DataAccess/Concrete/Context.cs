using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        public Context(DbContextOptions<Context> options) :base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost;Database=DormitoryDb;Trusted_Connection=True;");
        //}
        DbSet<Announcement> Announcements { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<MonthsForPay> Months { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<Suggestion_Complaint> Suggestions_Complaints { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
