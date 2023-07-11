using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class EventParticipantService : IEventParticipantService
    {
        private readonly IEventParticipantRepository _eventParticipantRepository;

        public EventParticipantService(IEventParticipantRepository eventParticipantRepository)
        {
            _eventParticipantRepository = eventParticipantRepository;
        }

        public async Task<bool> Create(EventParticipant entity)
        {
            return await _eventParticipantRepository.AddAsync(entity);
        }

        public async Task CreateRange(IEnumerable<EventParticipant> entity)
        {
            await _eventParticipantRepository.AddRangeAsync(entity);
        }

        public bool DeleteAsync(EventParticipant entity)
        {
            return _eventParticipantRepository.Delete(entity);
        }

        public void DeleteRange(IEnumerable<EventParticipant> entity)
        {
            _eventParticipantRepository.DeleteRange(entity);
        }

        public IEnumerable<EventParticipant> GetAll()
        {
            return _eventParticipantRepository.GetAll().ToList();
        }

        public IEnumerable<EventParticipant> GetByCondition(Expression<Func<EventParticipant, bool>> expression)
        {
            return _eventParticipantRepository.GetByCondition(expression).ToList();
        }

        public async Task<EventParticipant> GetOne(int id)
        {
            return await _eventParticipantRepository.GetOneById(id);
        }

        public bool Update(EventParticipant entity)
        {
            return _eventParticipantRepository.Update(entity);
        }

        public void UpdateRange(IEnumerable<EventParticipant> entity)
        {
            _eventParticipantRepository.UpdateRange(entity);
        }
        
        
    }
}
