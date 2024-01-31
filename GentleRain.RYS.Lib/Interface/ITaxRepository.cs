using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib.Interface
{
    public interface ITaxRepository<TEntity, TModel> : IRepository<TModel> where TEntity : class where TModel : Tax
    {
        Task<IEnumerable<TModel>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
