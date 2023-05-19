using System.ComponentModel.DataAnnotations;

namespace VehicleRegistry.Application.DataTransferObjects;

/// <summary>
/// Objeto base de transferência de dados comuns.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public abstract class CommonData : Data
{
    /// <summary>
    /// O ID do registro.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// O nome do registro.
    /// </summary>
    [Required]
    public string Name { get; set; } = "";

    /// <summary>
    /// A data de criação do registro.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// A data de atualização do regsitro.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}