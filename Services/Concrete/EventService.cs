using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<bool> Create(Event entity)
        {
            return await _eventRepository.AddAsync(entity);
        }

        public async Task CreateRange(IEnumerable<Event> entity)
        {
            await _eventRepository.AddRangeAsync(entity);
        }

        public bool DeleteAsync(Event entity)
        {
            return _eventRepository.Delete(entity);
        }

        public void DeleteRange(IEnumerable<Event> entity)
        {
            _eventRepository.DeleteRange(entity);
        }

        public IEnumerable<Event> GetAll()
        {
            return _eventRepository.GetAll().ToList();
        }

        public IEnumerable<Event> GetByCondition(Expression<Func<Event, bool>> expression)
        {
            return _eventRepository.GetByCondition(expression).ToList();
        }

        public async Task<Event> GetOne(int id)
        {
            return await _eventRepository.GetOneById(id);
        }

        public bool Update(Event entity)
        {
            return _eventRepository.Update(entity);
        }

        public void UpdateRange(IEnumerable<Event> entity)
        {
            _eventRepository.UpdateRange(entity);
        }
    }
}
