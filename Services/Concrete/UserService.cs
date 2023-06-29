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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Create(AppUser entity)
        {
            return await _userRepository.AddAsync(entity);
        }

        public async Task CreateRange(IEnumerable<AppUser> entity)
        {
            await _userRepository.AddRangeAsync(entity);
        }

        public bool Delete(AppUser entity)
        {
            return _userRepository.Delete(entity);
        }

        public void DeleteRange(IEnumerable<AppUser> entity)
        {
            _userRepository.DeleteRange(entity);
        }

        public IEnumerable<AppUser> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }

        public IEnumerable<AppUser> GetByCondition(Expression<Func<AppUser, bool>> expression)
        {
            return _userRepository.GetByCondition(expression).ToList();
        }

        public async Task<AppUser> GetOne(int id)
        {
            return await _userRepository.GetOneById(id);
        }

        public IEnumerable<AppUser> GetStudents()
        {
            return _userRepository.GetStudents().ToList();
        }

        public bool Update(AppUser entity)
        {
            return _userRepository.Update(entity);
        }

        public void UpdateRange(IEnumerable<AppUser> entity)
        {
            _userRepository.UpdateRange(entity);
        }
    }
}
