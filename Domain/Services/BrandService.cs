using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Repositories;

namespace VehicleRegistry.Domain.Services;

/// <summary>
/// Serviço de marca de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class BrandService : Service
{
    /// <summary>
    /// O repositório de marca.
    /// </summary>
    private BrandRepository repository;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="repository">O repositório de marca.</param>
    public BrandService(BrandRepository repository)
    {
        this.repository = repository;
    }

    /// <summary>
    /// Pega todas as marcas de veículos.
    /// </summary>
    /// <returns>As marcas de veículos.</returns>
    public async Task<List<BrandData>> GetAll()
    {
        // Pega as marcas do banco de dados.
        IEnumerable<Brand> results = await this.repository.GetAllAsync();
        var brands = new List<BrandData>();
        // Converte as entidades para DTO's.
        foreach (var brand in results)
        {
            brands.Add(new BrandData
            {
                Id = brand.Id,
                Name = brand.Name
            });
        }

        return brands;
    }

    /// <summary>
    /// Pega uma determinada marca pelo ID.
    /// </summary>
    /// <param name="id">O ID da marca.</param>
    /// <returns>Os dados da marca solicitada.</returns>
    public async Task<BrandData?> GetByID(Guid id)
    {
        // Faz o resgate da marca.
        Brand? brand = await this.repository.GetAsync(id);

        return (brand is not null) ? new BrandData {
            Name = brand.Name
        } : null;
    }

    /// <summary>
    /// Pega uma determinada entidade de marca pelo ID.
    /// </summary>
    /// <param name="id">O ID da marca.</param>
    /// <returns>Os dados da marca solicitada.</returns>
    public async Task<Brand?> GetEntity(Guid id)
    {
        return await this.repository.GetAsync(id);
    }
}