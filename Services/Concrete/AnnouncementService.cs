using DataAccess.Abstract;
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
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementService(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public async Task<bool> Create(Announcement entity)
        {
            return await _announcementRepository.AddAsync(entity);
        }

        public async Task CreateRange(IEnumerable<Announcement> entity)
        {
            await _announcementRepository.AddRangeAsync(entity);
        }

        public bool DeleteAsync(Announcement entity)
        {
            return _announcementRepository.Delete(entity);
        }

        public void DeleteRange(IEnumerable<Announcement> entity)
        {
            _announcementRepository.DeleteRange(entity);
        }

        public IEnumerable<Announcement> GetAll()
        {
           return _announcementRepository.GetAll().ToList();
        }

        public IEnumerable<Announcement> GetByCondition(Expression<Func<Announcement, bool>> expression)
        {
            return _announcementRepository.GetByCondition(expression).ToList();
        }

        public async Task<Announcement> GetOne(int id)
        {
            return await _announcementRepository.GetOneById(id);
        }

        public bool Update(Announcement entity)
        {
            return _announcementRepository.Update(entity);
        }

        public void UpdateRange(IEnumerable<Announcement> entity)
        {
            _announcementRepository.UpdateRange(entity);
        }
    }
}
