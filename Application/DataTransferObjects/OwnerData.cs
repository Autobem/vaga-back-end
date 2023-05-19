using System.ComponentModel.DataAnnotations;

namespace VehicleRegistry.Application.DataTransferObjects;

/// <summary>
/// Objeto de transferência de dados de proprietário.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class OwnerData : CommonData
{
    /// <summary>
    /// O sobrenome do proprietário.
    /// </summary>
    [Required]
    public string Surname { get; set; } = "";
}