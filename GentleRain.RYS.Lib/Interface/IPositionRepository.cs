using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib.Interface
{
    public interface IPositionRepository<TEntity, TModel> : IRepository<TModel> where TEntity : class where TModel : Position
    {
        Task<IEnumerable<TModel>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
