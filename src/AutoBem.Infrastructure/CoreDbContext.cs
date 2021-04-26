using AutoBem.Infrastructure.Clients.Entities;
using AutoBem.Infrastructure.Vehicles.Entities;
using BuildingBlocks.Infraestructure;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace AutoBem.Infrastructure
{
    public class CoreDbContext : DbContext, IDbContext
    {
        public CoreDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<ClientEntity> Clients { get; set; }

        public DbSet<VehicleEntity> Vehicles { get; set; }
    }
}
