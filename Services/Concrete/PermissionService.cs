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
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IStudentService _studentService;
        private readonly UserManager<AppUser> _userManager;

        public PermissionService(IPermissionRepository permissionRepository, UserManager<AppUser> userManager, IStudentService studentService)
        {
            _permissionRepository = permissionRepository;
            _userManager = userManager;
            _studentService = studentService;
        }
        public async Task<bool> Create(Permission entity)
        {
            if (entity.DateOfEnd > entity.DateOfStart)
            {
                return await _permissionRepository.AddAsync(entity);
            }
            else
            {
                throw new Exception("Bitiş tarihi, başlangıç tarihinden erken olamaz.");
            }
        }

        public async Task CreateRange(IEnumerable<Permission> entity)
        {
            await _permissionRepository.AddRangeAsync(entity);
        }

        public bool DeleteAsync(Permission entity)
        {
            return _permissionRepository.Delete(entity);
        }

        public void DeleteRange(IEnumerable<Permission> entity)
        {
            _permissionRepository.DeleteRange(entity);
        }

        public IEnumerable<Permission> GetAll()
        {
            return _permissionRepository.GetAll().ToList();
        }

        public IEnumerable<Permission> GetByCondition(Expression<Func<Permission, bool>> expression)
        {
            return _permissionRepository.GetByCondition(expression).ToList();
        }

        public async Task<Permission> GetOne(int id)
        {
            return await _permissionRepository.GetOneById(id);
        }

        public bool Update(Permission entity)
        {
            return _permissionRepository.Update(entity);
        }

        public void UpdateRange(IEnumerable<Permission> entity)
        {
            _permissionRepository.UpdateRange(entity);
        }

        public async Task<bool> AddPermissionsToStudentAsync(Permission permission)
        {
            var student = await _userManager.FindByIdAsync(permission.StudentId.ToString());
            if (student is null)
            {
                throw new DirectoryNotFoundException("Öğrenci bulunamadı.");
            }
            student.Permissions.Add(permission);
            TimeSpan span = permission.DateOfEnd.Subtract(permission.DateOfStart);
            if (student.PermissionRights > span.Days)
            {
                student.PermissionRights -= span.Days;
                var result = await _userManager.UpdateAsync(student);
                return result.Succeeded;
            }
            throw new Exception("Yeteri kadar izin hakkınız bulunmamaktadır.");
        }

        public IEnumerable<Permission> GetPermissionsOfStudent(int id)
        {
            var student = _studentService.GetStudentWithPermissions(id);
            if (student is null)
            {
                throw new DirectoryNotFoundException("Öğrenci kaydı bulunamadı.");
            }
            return student.Permissions;
        }
    }
}
