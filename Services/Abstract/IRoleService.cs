using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IRoleService
    {
        public IEnumerable<AppRole> GetRoles();
        public Task<bool> DeleteRoleAsync(AppRole entity);
        public Task<bool> CreateRoleAsync(AppRole entity);
        public IEnumerable<AppRole> GetRoleByCondition(Expression<Func<AppRole, bool>> expression);
        public Task<AppRole> GetOneRole(int id);
        public Task<bool> UpdateAsync(AppRole entity);
    }
}
