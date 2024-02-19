using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib.Interface
{
    public interface ITaxRepository : IRepository<Tax> 
    {
        Task<IEnumerable<Tax>> WhereAsync(Expression<Func<Tax, bool>> predicate);
    }
}
