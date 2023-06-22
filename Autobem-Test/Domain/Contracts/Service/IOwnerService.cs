using Domain.Models;

namespace Domain.Contracts.Service;

public interface IOwnerService
{
    Task<OwnerModel> Insert(OwnerModel owner);

    Task Update(OwnerModel owner);

    Task Delete(Guid id);

    Task<OwnerModel> GetById(Guid id);

    Task<IEnumerable<OwnerModel>> Get();
}