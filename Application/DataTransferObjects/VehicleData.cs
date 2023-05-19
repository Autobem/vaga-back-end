using System.ComponentModel.DataAnnotations;

using VehicleRegistry.Domain.Entities;

namespace VehicleRegistry.Application.DataTransferObjects;

/// <summary>
/// Objeto de transferência de dados de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleData : Data
{
    /// <summary>
    /// O ID do veículo.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// O ID do proprietário.
    /// </summary>
    [Required]
    public Guid OwnerId { get; set; }

    /// <summary>
    /// A relação do proprietário.
    /// </summary>
    public Owner Owner { get; set; }

    /// <summary>
    /// O ID da cor do veículo.
    /// </summary>
    [Required]
    public Guid ColorId { get; set; }

    /// <summary>
    /// A relação da cor do veículo.
    /// </summary>
    public VehicleColor Color { get; set; }

    /// <summary>
    /// O ID do tipo de combustível do veículo.
    /// </summary>
    [Required]
    public Guid FuelId { get; set; }

    /// <summary>
    /// A relação do tipo de combustível.
    /// </summary>
    public VehicleFuel Fuel { get; set; }

    /// <summary>
    /// O ID do modelo do veículo.
    /// </summary>
    [Required]
    public Guid ModelId { get; set; }

    /// <summary>
    /// A relação do modelo do veículo.
    /// </summary>
    public Model Model { get; set; }

    /// <summary>
    /// A placa do veículo.
    /// </summary>
    [Required]
    public string Plate { get; set; } = "";

    /// <summary>
    /// O ano do veículo.
    /// </summary>
    [Required]
    [Range(1000, 3000)]
    public int Year { get; set; }

    /// <summary>
    /// A data de registro do veículo.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// A data de atualização do registro do veículo.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    public VehicleData()
    {
        this.Owner = new Owner();
        this.Color = new VehicleColor();
        this.Fuel = new VehicleFuel();
        this.Model = new Model();
    }
}