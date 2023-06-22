using Entities.Entities;

namespace Domain.Contracts.Service;

public interface IOwnerService
{
    Task Insert(Owner owner);
    Task Update(Owner owner);
    Task Delete(Owner owner);
    Task GetById(Guid id);
    Task<IEnumerable<Owner>> Get();
}