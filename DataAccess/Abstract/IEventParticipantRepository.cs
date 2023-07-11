using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEventParticipantRepository : IGenericRepository<EventParticipant>
    {
        public IQueryable<EventParticipant> Join { get; }
        public IQueryable<EventParticipant> GetEventsOfStudent(int id);
        public IQueryable<EventParticipant> GetStudentsOfEvent(int id);
    }
}
