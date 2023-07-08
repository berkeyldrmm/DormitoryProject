using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
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
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(IRoleRepository roleRepository, RoleManager<AppRole> roleManager)
        {
            _roleRepository = roleRepository;
            _roleManager = roleManager;
        }
        
        public async Task<bool> CreateRoleAsync(AppRole entity)
        {
            var result= await _roleManager.CreateAsync(entity);
            return result.Succeeded;
        }

        public async Task CreateRange(IEnumerable<AppRole> entity)
        {
            await _roleRepository.AddRangeAsync(entity);
        }

        public async Task<bool> DeleteRoleAsync(AppRole entity)
        {
            var result= await _roleManager.DeleteAsync(entity);
            return result.Succeeded;
        }

        public void DeleteRange(IEnumerable<AppRole> entity)
        {
            _roleRepository.DeleteRange(entity);
        }

        public IEnumerable<AppRole> GetRoles()
        {
            return _roleManager.Roles.ToList();
        }

        public IEnumerable<AppRole> GetRoleByCondition(Expression<Func<AppRole, bool>> expression)
        {
            return _roleManager.Roles.Where(expression).ToList();
        }

        public async Task<AppRole> GetOneRole(int id)
        {
            return await _roleManager.FindByIdAsync(id.ToString());
        }

        public async Task<bool> UpdateAsync(AppRole role)
        {
            var result= await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }

        public void UpdateRange(IEnumerable<AppRole> role)
        {
            _roleRepository.UpdateRange(role);
        }
    }
}
