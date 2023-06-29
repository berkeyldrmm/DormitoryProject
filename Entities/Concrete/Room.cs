using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNo { get; set; }
        public int Quota { get; set; }
        public int NumberOfStudents { get; set; }
        public bool Availability { get; set; }
        public ICollection<AppUser> Students { get; set; }
    }
}
