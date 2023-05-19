using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Repositories;

namespace VehicleRegistry.Domain.Services;

/// <summary>
/// Serviço de tipo de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class VehicleTypeService : Service
{
    /// <summary>
    /// O repositório de tipo de veículo.
    /// </summary>
    private VehicleTypeRepository repository;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="repository">O repositório de tipo de veículo.</param>
    public VehicleTypeService(VehicleTypeRepository repository)
    {
        this.repository = repository;
    }

    /// <summary>
    /// Pega todos os tipos de veículos.
    /// </summary>
    /// <returns>Os tipos de veículos.</returns>
    public async Task<List<VehicleTypeData>> GetAll()
    {
        // Resgata os tipos de veículos do banco de dados.
        IEnumerable<VehicleType> results = await this.repository.GetAllAsync();
        // Converte as entidades em DTO's.
        var types = new List<VehicleTypeData>();
        foreach (var type in results)
        {
            types.Add(new VehicleTypeData
            {
                Id = type.Id,
                Name = type.Name
            });
        }

        return types;
    }

    /// <summary>
    /// Pega um determinado tipo de veículo pelo ID.
    /// </summary>
    /// <param name="id">O ID do tipo de veículo.</param>
    /// <returns>Os dados do tipo de veículo solicitado.</returns>
    public async Task<VehicleTypeData?> GetByID(Guid id)
    {
        VehicleType? brand = await this.repository.GetAsync(id);

        return (brand is not null) ? new VehicleTypeData {
            Name = brand.Name
        } : null;
    }

    /// <summary>
    /// Pega a entidade de um determinado tipo de veículo pelo ID.
    /// </summary>
    /// <param name="id">O ID do tipo de veículo.</param>
    /// <returns>Os dados do tipo de veículo solicitado.</returns>
    public async Task<VehicleType?> GetEntity(Guid id)
    {
        return await this.repository.GetAsync(id);
    }
}