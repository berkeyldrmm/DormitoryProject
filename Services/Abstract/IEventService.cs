﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IEventService : IGenericService<Event>
    {
        public IEnumerable<EventParticipant> GetEventsOfStudent(int id);
    }
}
