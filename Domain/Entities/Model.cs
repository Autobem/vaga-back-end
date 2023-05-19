using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleRegistry.Domain.Entities;

/// <summary>
/// Entidade de modelo de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class Model : IEntity
{
    /// <summary>
    /// O ID do modelo.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// O ID da marca.
    /// </summary>
    public Guid BrandId { get; set; }

    /// <summary>
    /// A relação da marca.
    /// </summary>
    public Brand Brand { get; set; }

    /// <summary>
    /// O ID do tipo de veículo.
    /// </summary>
    public Guid TypeId { get; set; }

    /// <summary>
    /// A relação do tipo de veículo.
    /// </summary>
    public VehicleType Type { get; set; }

    /// <summary>
    /// O nome do modelo.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// A data de registro do modelo.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// A data de atualização do registro do modelo.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    public Model()
    {
        this.Brand = new Brand();
        this.Type = new VehicleType();
    }
}