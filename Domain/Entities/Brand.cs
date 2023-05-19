using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleRegistry.Domain.Entities;

/// <summary>
/// Entidade de marca.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class Brand : IEntity
{
    /// <summary>
    /// O ID da marca.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// O nome da marca.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// A data de registro da marca.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// A data de atualização do registro da marca.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}