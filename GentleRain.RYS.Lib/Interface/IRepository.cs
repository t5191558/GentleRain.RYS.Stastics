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
        Task<T?> GetByCodeAsync(string code);
        Task<List<T>> GetAllAsync();
        

        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        Task Update(T entity);
        Task Update(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
