using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public AppUser()
        {
            Events = new HashSet<EventParticipant>();
            Permissions = new HashSet<Permission>();
            Suggestions_Complaints= new HashSet<Suggestion_Complaint>();
            PaymentRecords = new HashSet<PaymentRecord>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public string ParentName_Surname { get; set; }
        public string ParentPhoneNumber { get; set; }
        public ICollection<EventParticipant> Events { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public ICollection<Suggestion_Complaint> Suggestions_Complaints { get; set; }
        public ICollection<PaymentRecord> PaymentRecords { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int PermissionRights { get; set; }
        public string School { get; set; }
        public string? Department { get; set; }
    }
}
