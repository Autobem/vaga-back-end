namespace VehicleRegistry.Domain.Entities;

/// <summary>
/// Contrato para entidades.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
interface IEntity
{
    /// <summary>
    /// A data de criação do registro.
    /// </summary>
    DateTime CreatedAt { get; set; }

    /// <summary>
    /// A data de atualização do regsitro.
    /// </summary>
    DateTime? UpdatedAt { get; set; }
}