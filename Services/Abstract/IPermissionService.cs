using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IPermissionService : IGenericService<Permission>
    {
        public Task<bool> AddPermissionsToStudentAsync(Permission permission);
        public IEnumerable<Permission> GetPermissionsOfStudent(int id);
    }
}
