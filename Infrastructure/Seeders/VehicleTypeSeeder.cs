using Microsoft.EntityFrameworkCore;

using VehicleRegistry.Domain.Entities;

namespace VehicleRegistry.Infrastructure.Seeders;

/// <summary>
/// Semeador de tipo de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleTypeSeeder : Seeder
{
    /// <summary>
    /// Popula a tablela de tipos de veículos.
    /// </summary>
    /// <param name="builder">O modelador de dados para o contexto atual.</param>
    /// <remarks>Este método não retorna valor.</remarks>
    public override void Seed(ModelBuilder builder)
    {
        var now = DateTime.UtcNow;
        
        builder.Entity<VehicleType>().HasData(
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Crossover",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Esportivo",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Furgão",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Hatch",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Minivan",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Perua",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Picape",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "Sedã",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleType
            {
                Id = Guid.NewGuid(),
                Name = "SUV",
                CreatedAt = now,
                UpdatedAt = now
            }
        );
    }
}