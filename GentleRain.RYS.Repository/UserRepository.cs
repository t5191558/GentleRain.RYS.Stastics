using GentleRain.RYS.Lib.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Repository
{
    public class UserRepository : BaseRepository, IUserRepository<User,Lib.User>
    {        
        public UserRepository(StasticDbContext dbContext):base(dbContext){}

        public Task AddAsync(Lib.User entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Lib.User> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<Lib.User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Lib.User?> GetByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public void Remove(Lib.User entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Lib.User> entities)
        {
            throw new NotImplementedException();
        }

        public Task Update(Lib.User entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(IEnumerable<Lib.User> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Lib.User>> WhereAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
