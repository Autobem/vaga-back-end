using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleRegistry.Domain.Entities;

/// <summary>
/// Entidade de proprietário.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class Owner : IEntity
{
    /// <summary>
    /// O ID do proprietário.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// O nome do proprietário.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// O sobrenome do proprietário.
    /// </summary>

    public string Surname { get; set; } = "";

    /// <summary>
    /// A data de registro do proprietário.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// A data de atualização do registro do proprietário.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}