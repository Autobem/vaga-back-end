using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Data.Mappings;
using Vehicles.API.Domain.Entities;

namespace Vehicles.API.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> option) : base(option)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(new UserMap().Configure);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrador",
                    Email = "admin@admin.com",
                    Password = "12345678",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}