using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthRevenue.Repository
{
    public class MonthContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BonusMainEntity>(entity =>
            {
                entity.HasIndex(e => e.IsDefault)
                      .HasFilter("IsDefault = 1")
                      .IsUnique();
                entity.HasCheckConstraint("CK_BonusMain_IsDefaultRequiresActive", "IsActive = 1 OR IsDefault = 0");
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<BonusMainEntity> BonusMain { get; set; }
        public DbSet<BonusEntity> Bonus { get; set; } 
        public DbSet<RevenueEntity> Revenue { get; set; }
        public DbSet<RevenueDetailEntity> RevenueDetail { get; set; }
        public DbSet<RevenueDayEntity> RevenueDay { get; set; }

    }
}
