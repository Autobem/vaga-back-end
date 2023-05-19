using Microsoft.EntityFrameworkCore;

using VehicleRegistry.Domain.Entities;

namespace VehicleRegistry.Infrastructure.Seeders;

/// <summary>
/// Semeador de marca.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class BrandSeeder : Seeder
{
    /// <summary>
    /// Popula a tablela de marcas.
    /// </summary>
    /// <param name="builder">O modelador de dados para o contexto atual.</param>
    /// <remarks>Este método não retorna valor.</remarks>
    public override void Seed(ModelBuilder builder)
    {
        var now = DateTime.UtcNow;

        builder.Entity<Brand>().HasData(
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Fiat",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "GM",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Volkswagen",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Toyota",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Hyundai",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Jeep",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Renault",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Honda",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Nissan",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Peugeot",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Ford",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Chevrolet",
                CreatedAt = now,
                UpdatedAt = now
            }
        );
    }
}