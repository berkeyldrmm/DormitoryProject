using AutoMapper;
using DataAccess.Abstract;
using DataAccess.Repositories;
using DTOs.AuthenticationDTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class UserService : UserManager<AppUser> , IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserStore<AppUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<AppUser> passwordHasher, IEnumerable<IUserValidator<AppUser>> userValidators, IEnumerable<IPasswordValidator<AppUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<AppUser>> logger, IUserRepository userRepository, IMapper mapper) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(AppUser entity)
        {
            return await _userRepository.AddAsync(entity);
        }

        public async Task CreateRange(IEnumerable<AppUser> entity)
        {
            await _userRepository.AddRangeAsync(entity);
        }

        public async Task<bool> CreateStudent(UserDTO userDto)
        {
            AppUser user = _mapper.Map<AppUser>(userDto);
            user.UserName = userDto.Email;
            user.Date = DateTime.Now;
            user.PermissionRights = 60;
            var result = await CreateAsync(user, userDto.Password);
            if (result.Succeeded)
            {
                var result2 = await AddToRoleAsync(user, "Öğrenci");
                return result2.Succeeded;
            }
            return false;
        }

        public async Task<bool> Delete(AppUser entity)
        {
            var result=await DeleteAsync(entity);
            return result.Succeeded;
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
