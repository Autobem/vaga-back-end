using System.ComponentModel.DataAnnotations;

using VehicleRegistry.Domain.Entities;

namespace VehicleRegistry.Application.DataTransferObjects;

/// <summary>
/// Objeto de transferência de dados de modelo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class ModelData : CommonData
{
    /// <summary>
    /// O ID da marca de veículo.
    /// </summary>
    [Required]
    public Guid BrandId { get; set; }

    /// <summary>
    /// A referência à marca.
    /// </summary>
    public Brand Brand { get; set; }

    /// <summary>
    /// O ID do tipo de veículo.
    /// </summary>
    [Required]
    public Guid TypeId { get; set; }

    /// <summary>
    /// A referência ao tipo de veículo.
    /// </summary>
    public VehicleType Type { get; set; }

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    public ModelData()
    {
        this.Brand = new Brand();
        this.Type = new VehicleType();
    }
}