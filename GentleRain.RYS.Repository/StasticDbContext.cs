using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Repository
{
    public class StasticDbContext : DbContext
    {
        private readonly string connectionstring = "Data Source=Stastic.db";
        public StasticDbContext()
        {

        }

        public StasticDbContext(string connection)
        {
            connectionstring = connection;
        }

        public StasticDbContext(DbContextOptions<StasticDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionstring);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Tax> Taxs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Order> Orders { get; set; }

    }

    public class StasticDbContextFactory : IDesignTimeDbContextFactory<StasticDbContext>
    {
        public StasticDbContext CreateDbContext(string[] args)
        {
            return new StasticDbContext();
        }
    }


}
