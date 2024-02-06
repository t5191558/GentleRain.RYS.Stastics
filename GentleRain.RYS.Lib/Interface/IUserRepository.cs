using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib.Interface
{
    public interface IUserRepository : IRepository<User> 
    {
        Task<User> GetByNameAsync(string name);
        Task<IEnumerable<User>> WhereAsync(Expression<Func<User, bool>> predicate);
    }
}
