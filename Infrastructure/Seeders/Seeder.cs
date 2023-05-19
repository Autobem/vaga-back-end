using Microsoft.EntityFrameworkCore;

namespace VehicleRegistry.Infrastructure.Seeders;

/// <summary>
/// Base para todos os semeadores.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public abstract class Seeder
{
    /// <summary>
    /// Popula determinada tabela.
    /// </summary>
    /// <param name="builder">O modelador de dados para o contexto atual.</param>
    /// <remarks>Este método não retorna valor.</remarks>
    public abstract void Seed(ModelBuilder builder);
}