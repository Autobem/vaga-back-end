using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using VehicleRegistry.Domain.Entities;

namespace VehicleRegistry.Infrastructure.Contexts;

/// <summary>
/// Contexto de banco de dados para a lógica de identidade.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class IdentityContext : IdentityDbContext<User>
{
    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="options">As configurações de conexão com o banco de dados.</param>
    public IdentityContext(
        DbContextOptions<IdentityContext> options
    ) : base(options)
    { }

    /// <summary>
    /// Define operações a serem realizadas durante o salvamento da entidade.
    /// </summary>
    /// <param name="cancellatonToken">Opção de cancelamento da operação assíncrona.</param>
    /// <returns>O número de entradas no banco de dados.</returns>
    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default
    )
    {
        // Pega a data e hora atual.
        var now = DateTime.UtcNow;

        // Atualiza as entidades para definir a data de criação e de
        // atualização.
        foreach (var entry in ChangeTracker.Entries<IEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;
            }

            entry.Entity.UpdatedAt = now;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}