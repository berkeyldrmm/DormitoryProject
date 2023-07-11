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
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(Context context) : base(context)
        {
        }
        //public IQueryable<Event> GetEventsWithParticipant()
        //{
        //    return Entity.Include(e => e.Students).AsQueryable();
        //}
        
    }
}
