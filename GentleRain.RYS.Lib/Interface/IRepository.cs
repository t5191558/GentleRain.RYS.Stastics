using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(object id);
        Task<List<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        Task<int> SaveChangesAsync();

    }
}
