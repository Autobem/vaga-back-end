using Microsoft.EntityFrameworkCore;

using VehicleRegistry.Domain.Entities;

namespace VehicleRegistry.Infrastructure.Seeders;

/// <summary>
/// Semeador de combustível de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleFuelSeeder : Seeder
{
    /// <summary>
    /// Popula a tablela de combustíveis.
    /// </summary>
    /// <param name="builder">O modelador de dados para o contexto atual.</param>
    /// <remarks>Este método não retorna valor.</remarks>
    public override void Seed(ModelBuilder builder)
    {
        var now = DateTime.UtcNow;

        builder.Entity<VehicleFuel>().HasData(
            new VehicleFuel
            {
                Id = Guid.NewGuid(),
                Name = "Álcool",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleFuel
            {
                Id = Guid.NewGuid(),
                Name = "Diesel",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleFuel
            {
                Id = Guid.NewGuid(),
                Name = "Gás",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleFuel
            {
                Id = Guid.NewGuid(),
                Name = "Gasolina",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleFuel
            {
                Id = Guid.NewGuid(),
                Name = "Flex",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleFuel
            {
                Id = Guid.NewGuid(),
                Name = "Nenhum",
                CreatedAt = now,
                UpdatedAt = now
            }
        );
    }
}