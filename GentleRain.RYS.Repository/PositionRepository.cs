using GentleRain.RYS.Lib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Repository
{
    public class PositionRepository : BaseRepository, IPositionRepository<Position, Lib.Position>
    {        
        public PositionRepository(StasticDbContext dbContext) : base(dbContext){}
        public Task AddAsync(Lib.Position entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Lib.Position> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<Lib.Position>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Lib.Position?> GetByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public void Remove(Lib.Position entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Lib.Position> entities)
        {
            throw new NotImplementedException();
        }

        public Task Update(Lib.Position entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(IEnumerable<Lib.Position> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Lib.Position>> WhereAsync(Expression<Func<Position, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<Lib.Position> IRepository<Lib.Position>.AddAsync(Lib.Position entity)
        {
            throw new NotImplementedException();
        }
    }
}
