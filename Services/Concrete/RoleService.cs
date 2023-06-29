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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<bool> Create(AppRole entity)
        {
            return await _roleRepository.AddAsync(entity);
        }

        public async Task CreateRange(IEnumerable<AppRole> entity)
        {
            await _roleRepository.AddRangeAsync(entity);
        }

        public bool Delete(AppRole entity)
        {
            return _roleRepository.Delete(entity);
        }

        public void DeleteRange(IEnumerable<AppRole> entity)
        {
            _roleRepository.DeleteRange(entity);
        }

        public IEnumerable<AppRole> GetAll()
        {
            return _roleRepository.GetAll().ToList();
        }

        public IEnumerable<AppRole> GetByCondition(Expression<Func<AppRole, bool>> expression)
        {
            return _roleRepository.GetByCondition(expression).ToList();
        }

        public async Task<AppRole> GetOne(int id)
        {
            return await _roleRepository.GetOneById(id);
        }

        public bool Update(AppRole entity)
        {
            return _roleRepository.Update(entity);
        }

        public void UpdateRange(IEnumerable<AppRole> entity)
        {
            _roleRepository.UpdateRange(entity);
        }
    }
}
