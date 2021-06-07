using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<HeroiBatalha>(entity =>
            //{
            //    entity.HasKey(e => new { e.BatalhaId, e.HeroiId });
            //});
        }
    }
}