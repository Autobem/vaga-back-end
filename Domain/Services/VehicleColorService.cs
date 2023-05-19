using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Repositories;

namespace VehicleRegistry.Domain.Services;

/// <summary>
/// Serviço de cor de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleColorService : Service
{
    /// <summary>
    /// O repositório de cor de veículo.
    /// </summary>
    private VehicleColorRepository repository;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="repository">O repositório de cor de veículo.</param>
    public VehicleColorService(VehicleColorRepository repository)
    {
        this.repository = repository;
    }

    /// <summary>
    /// Pega todas as cores de veículos.
    /// </summary>
    /// <returns>As cores de veículos.</returns>
    public async Task<List<VehicleColorData>> GetAll()
    {
        // Resgata as cores do banco de dados.
        IEnumerable<VehicleColor> results = await this.repository.GetAllAsync();
        var colors = new List<VehicleColorData>();
        // Converte as entidades para DTO's.
        foreach (var color in results)
        {
            colors.Add(new VehicleColorData
            {
                Id = color.Id,
                Name = color.Name
            });
        }

        return colors;
    }

    /// <summary>
    /// Pega uma determinada cor pelo ID.
    /// </summary>
    /// <param name="id">O ID da cor.</param>
    /// <returns>Os dados da cor solicitada.</returns>
    public async Task<VehicleColorData?> GetByID(Guid id)
    {
        VehicleColor? color = await this.repository.GetAsync(id);

        return (color is not null) ? new VehicleColorData {
            Name = color.Name
        } : null;
    }

    /// <summary>
    /// Pega uma determinada entidade de cor pelo ID.
    /// </summary>
    /// <param name="id">O ID da cor.</param>
    /// <returns>Os dados da cor solicitada.</returns>
    public async Task<VehicleColor?> GetEntity(Guid id)
    {
        return await this.repository.GetAsync(id);
    }
}