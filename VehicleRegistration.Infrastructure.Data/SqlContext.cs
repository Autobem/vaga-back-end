using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VehicleRegistration.Domain.Models;

namespace VehicleRegistration.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateRegister") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateRegister").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateRegister").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
