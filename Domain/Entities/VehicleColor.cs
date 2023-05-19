using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleRegistry.Domain.Entities;

/// <summary>
/// Entidade de cor do veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleColor : IEntity
{
    /// <summary>
    /// O ID da cor do veículo.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// O nome da cor.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// A data de registro da cor.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// A data de atualização do registro da cor.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}