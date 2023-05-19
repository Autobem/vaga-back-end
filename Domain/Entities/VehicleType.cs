using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleRegistry.Domain.Entities;

/// <summary>
/// Entidade de tipo de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleType : IEntity
{
    /// <summary>
    /// O ID do tipo de veículo.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// O nome do tipo de veículo.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// A data de registro do tipo.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// A data de atualização do registro do tipo.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}