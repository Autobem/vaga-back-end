using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Repositories;

namespace VehicleRegistry.Domain.Services;

/// <summary>
/// Serviço de modelo de veículo.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class ModelService : Service
{
    /// <summary>
    /// O repositório de modelo.
    /// </summary>
    private ModelRepository repository;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="repository">O repositório de modelo.</param>
    public ModelService(ModelRepository repository)
    {
        this.repository = repository;
    }

    /// <summary>
    /// Cria um novo modelo de veículo.
    /// </summary>
    /// <param name="model">Os dados do novo modelo.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public async Task Create(ModelData model)
    {
        // Adiciona o novo modelo.
        await this.repository.AddAsync(new Model {
            Brand = model.Brand,
            Type = model.Type,
            Name = model.Name
        });
    }

    /// <summary>
    /// Pega um determinado modelo pelo ID.
    /// </summary>
    /// <param name="id">O ID do modelo.</param>
    /// <returns>Os dados do modelo solicitado.</returns>
    public async Task<ModelData?> GetByID(Guid id)
    {
        // Faz o resgate do modelo.
        Model? model = await this.repository.GetAsync(id);

        return (model is not null) ? new ModelData {
            Name = model.Name
        } : null;
    }

    /// <summary>
    /// Pega os modelos pelo ID da marca.
    /// </summary>
    /// <param name="brandId">O ID da marca.</param>
    /// <returns>A lista dos modelos.</returns>
    public async Task<List<ModelData>> GetModelsByBrand(Guid brandId)
    {
        // Pega os modelos.
        IEnumerable<Model> results = await this.repository.GetByBrandAsync(
            brandId
        );
        var models = new List<ModelData>();
        // Converte as entidades para DTO's.
        foreach (var model in results)
        {
            models.Add(new ModelData
            {
                Id = model.Id,
                BrandId = model.BrandId,
                Brand = model.Brand,
                TypeId = model.TypeId,
                Type = model.Type,
                Name = model.Name
            });
        }

        return models;
    }

    /// <summary>
    /// Pega uma determinada entidade de modelo pelo ID.
    /// </summary>
    /// <param name="id">O ID do modelo.</param>
    /// <returns>Os dados do modelo solicitado.</returns>
    public async Task<Model?> GetEntity(Guid id)
    {
        return await this.repository.GetAsync(id);
    }
}