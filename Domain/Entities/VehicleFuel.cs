using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleRegistry.Domain.Entities;

/// <summary>
/// Entidade de combustível do veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleFuel : IEntity
{
    /// <summary>
    /// O ID do combustível.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// O nome do combustível.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// A data de registro do combustível.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// A data de atualização do registro da cor.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}