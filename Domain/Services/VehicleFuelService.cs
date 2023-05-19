using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Repositories;

namespace VehicleRegistry.Domain.Services;

/// <summary>
/// Serviço de combustível de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleFuelService : Service
{
    /// <summary>
    /// O repositório de combustível de veículo.
    /// </summary>
    private VehicleFuelRepository repository;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="repository">O repositório de combustível.</param>
    public VehicleFuelService(VehicleFuelRepository repository)
    {
        this.repository = repository;
    }

    /// <summary>
    /// Pega todos os combustíveis de veículos.
    /// </summary>
    /// <returns>Os combustíveis de veículos.</returns>
    public async Task<List<VehicleFuelData>> GetAll()
    {
        // Resgata os combustíveis do banco da dados.
        IEnumerable<VehicleFuel> results = await this.repository.GetAllAsync();
        // Converte as entidades para DTO's.
        var fuels = new List<VehicleFuelData>();
        foreach (var fuel in results)
        {
            fuels.Add(new VehicleFuelData
            {
                Id = fuel.Id,
                Name = fuel.Name
            });
        }

        return fuels;
    }

    /// <summary>
    /// Pega um determinado tipo de combustível pelo ID.
    /// </summary>
    /// <param name="id">O ID do tipo de combustível.</param>
    /// <returns>Os dados do tipo de combustível solicitado.</returns>
    public async Task<VehicleFuelData?> GetByID(Guid id)
    {
        VehicleFuel? fuel = await this.repository.GetAsync(id);

        return (fuel is not null) ? new VehicleFuelData {
            Name = fuel.Name
        } : null;
    }

    /// <summary>
    /// Pega uma determinada entidade de combustível pelo ID.
    /// </summary>
    /// <param name="id">O ID do combustível.</param>
    /// <returns>Os dados do combustível solicitado.</returns>
    public async Task<VehicleFuel?> GetEntity(Guid id)
    {
        return await this.repository.GetAsync(id);
    }
}