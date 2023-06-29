using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetOne(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByCondition(Expression<Func<T,bool>> expression);
        Task<bool> Create(T entity);
        Task CreateRange(IEnumerable<T> entity);
        bool Update(T entity);
        void UpdateRange(IEnumerable<T> entity);
        bool Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);

    }
}
