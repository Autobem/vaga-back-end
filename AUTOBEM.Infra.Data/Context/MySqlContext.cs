using AUTOBEM.Domain.Entities;
using AUTOBEM.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AUTOBEM.Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Vehicle>(new VehicleMap().Configure);
            modelBuilder.Entity<Owner>(new OwnerMap().Configure);
        }
    }
}
