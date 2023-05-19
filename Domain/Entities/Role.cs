using Microsoft.AspNetCore.Identity;

namespace VehicleRegistry.Domain.Entities;

/// <summary>
/// Entidade de função do usuário.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class Role : IdentityRole, IEntity
{
    /// <summary>
    /// A data de registro da função.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// A data de atualização de registro da função.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}