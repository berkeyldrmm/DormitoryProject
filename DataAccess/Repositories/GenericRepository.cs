using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Context _context { get; set; }

        public DbSet<T> Entity => _context.Set<T>();

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Entity.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await Entity.AddRangeAsync(entity);
        }

        public bool Delete(T entity)
        {
            EntityEntry<T> entityEntry = Entity.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteById(int id)
        {
            T data = await Entity.FindAsync(id);
            EntityEntry<T> entityEntry = Entity.Remove(data);
            return entityEntry.State == EntityState.Deleted;
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            Entity.RemoveRange(entities);
        }

        public IQueryable<T> GetAll()
        {
            return Entity.AsQueryable();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return Entity.Where(expression).AsQueryable();
        }

        public async Task<T> GetOneById(int id)
        {
            return await Entity.FindAsync(id);
        }

        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Entity.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Entity.UpdateRange(entities);
        }
    }
}
