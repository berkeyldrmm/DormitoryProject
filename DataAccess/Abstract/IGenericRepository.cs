using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        DbSet<T> Entity { get; }
        IQueryable<T> GetAll();
        Task<T> GetOneById(int id);
        IQueryable<T> GetByCondition(Expression<Func<T,bool>> expression);
        Task<bool> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);
        bool Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        bool Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        Task<bool> DeleteById(int id);
    }
}
