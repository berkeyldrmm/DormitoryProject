using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Event
    {
        public Event()
        {
            Students = new HashSet<EventParticipant>();
        }
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public ICollection<EventParticipant> Students { get; set; }
    }
}
