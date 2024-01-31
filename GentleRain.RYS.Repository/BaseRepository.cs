using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Repository
{
    public class BaseRepository
    {
        private readonly StasticDbContext dbContext;
        public BaseRepository(StasticDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
