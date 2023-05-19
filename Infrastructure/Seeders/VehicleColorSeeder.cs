using Microsoft.EntityFrameworkCore;

using VehicleRegistry.Domain.Entities;

namespace VehicleRegistry.Infrastructure.Seeders;

/// <summary>
/// Semeador de cor de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleColorSeeder : Seeder
{
    /// <summary>
    /// Popula a tablela de cores de veículos.
    /// </summary>
    /// <param name="builder">O modelador de dados para o contexto atual.</param>
    /// <remarks>Este método não retorna valor.</remarks>
    public override void Seed(ModelBuilder builder)
    {
        var now = DateTime.UtcNow;

        builder.Entity<VehicleColor>().HasData(
            new VehicleColor
            {
                Id = Guid.NewGuid(),
                Name = "Azul",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleColor
            {
                Id = Guid.NewGuid(),
                Name = "Branco",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleColor
            {
                Id = Guid.NewGuid(),
                Name = "Cinza",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleColor
            {
                Id = Guid.NewGuid(),
                Name = "Preto",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleColor
            {
                Id = Guid.NewGuid(),
                Name = "Verde",
                CreatedAt = now,
                UpdatedAt = now
            },
            new VehicleColor
            {
                Id = Guid.NewGuid(),
                Name = "Vermelho",
                CreatedAt = now,
                UpdatedAt = now
            }
        );
    }
}