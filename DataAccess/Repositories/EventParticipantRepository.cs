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
    public class EventParticipantRepository : GenericRepository<EventParticipant>, IEventParticipantRepository
    {
        public EventParticipantRepository(Context context) : base(context)
        {
        }
        public IQueryable<EventParticipant> Join => Entity.Include(ep => ep.Event).Include(ep => ep.Student);
        public IQueryable<EventParticipant> GetEventsOfStudent(int id)
        {
            return Join.Where(e => e.StudentId == id).AsQueryable();
        }
        
        public IQueryable<EventParticipant> GetStudentsOfEvent(int id)
        {
            return Join.Where(e => e.EventId == id).AsQueryable();
        }
    }
}
