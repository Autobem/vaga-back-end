using VehicleRegistry.Application.DataTransferObjects;
using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Repositories;

namespace VehicleRegistry.Domain.Services;

/// <summary>
/// Serviço de proprietário.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class OwnerService : Service
{
    /// <summary>
    /// O repositório de proprietário.
    /// </summary>
    private OwnerRepository repository;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="repository">O repositório de proprietário.</param>
    public OwnerService(OwnerRepository repository)
    {
        this.repository = repository;
    }

    /// <summary>
    /// Cria um novo proprietário.
    /// </summary>
    /// <param name="owner">Os dados do novo proprietário.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public async Task Create(OwnerData owner)
    {
        await this.repository.AddAsync(new Owner {
            Name = owner.Name,
            Surname = owner.Surname
        });
    }

    /// <summary>
    /// Pega todos os proprietários de veículos.
    /// </summary>
    /// <returns>Os proprietários de veículos.</returns>
    public async Task<List<OwnerData>> GetAll()
    {
        IEnumerable<Owner> results = await this.repository.GetAllAsync();
        var owners = new List<OwnerData>();
        foreach (var owner in results)
        {
            owners.Add(new OwnerData
            {
                Id = owner.Id,
                Name = owner.Name,
                Surname = owner.Surname
            });
        }

        return owners;
    }

    /// <summary>
    /// Pega um determinado proprietário pelo ID.
    /// </summary>
    /// <param name="id">O ID do proprietário.</param>
    /// <returns>Os dados do proprietário solicitado.</returns>
    public async Task<OwnerData?> GetByID(Guid id)
    {
        Owner? owner = await this.repository.GetAsync(id);

        return (owner is not null) ? new OwnerData {
            Id = owner.Id,
            Name = owner.Name,
            Surname = owner.Surname,
            CreatedAt = owner.CreatedAt,
            UpdatedAt = owner.UpdatedAt
        } : null;
    }

    /// <summary>
    /// Exclui um determinado proprietário pelo ID.
    /// </summary>
    /// <param name="id">O ID do proprietário.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public async Task RemoveOwnerByID(Guid id)
    {
        await this.repository.RemoveAsync(id);
    }

    /// <summary>
    /// Atualiza um determinado proprietário pelo ID.
    /// </summary>
    /// <param name="data">Os novos dados do proprietário.</param>
    /// <returns>A tarefa do método assíncrono.</returns>
    public async Task UpdateOwnerByID(OwnerData data)
    {
        await this.repository.UpdateAsync(data);
    }

    /// <summary>
    /// Pega uma determinada entidade de proprietário pelo ID.
    /// </summary>
    /// <param name="id">O ID do proprietário.</param>
    /// <returns>Os dados do proprietário solicitado.</returns>
    public async Task<Owner?> GetEntity(Guid id)
    {
        return await this.repository.GetAsync(id);
    }
}