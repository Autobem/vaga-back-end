using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleRegistry.Domain.Entities;

/// <summary>
/// Entidade de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class Vehicle : IEntity
{
    /// <summary>
    /// O ID do veículo.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// O ID do proprietário.
    /// </summary>
    public Guid OwnerId { get; set; }

    /// <summary>
    /// A relação do proprietário.
    /// </summary>
    public Owner Owner { get; set; }

    /// <summary>
    /// O ID da cor do veículo.
    /// </summary>
    public Guid ColorId { get; set; }

    /// <summary>
    /// A relação da cor do veículo.
    /// </summary>
    public VehicleColor Color { get; set; }

    /// <summary>
    /// O ID do tipo de combustível.
    /// </summary>
    public Guid FuelId { get; set; }

    /// <summary>
    /// A relação do tipo de combustível.
    /// </summary>
    public VehicleFuel Fuel { get; set; }

    /// <summary>
    /// O ID do modelo do veículo.
    /// </summary>
    public Guid ModelId { get; set; }

    /// <summary>
    /// A relação do modelo do veículo.
    /// </summary>
    public Model Model { get; set; }

    /// <summary>
    /// A placa do veículo.
    /// </summary>
    public string Plate { get; set; } = "";

    /// <summary>
    /// O ano do veículo.
    /// </summary>
    public int Year { get; set; } = 0;

    /// <summary>
    /// A data de registro do veículo.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// A data de atualização do registro do proprietário.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    public Vehicle()
    {
        this.Owner = new Owner();
        this.Color = new VehicleColor();
        this.Fuel = new VehicleFuel();
        this.Model = new Model();
    }
}
