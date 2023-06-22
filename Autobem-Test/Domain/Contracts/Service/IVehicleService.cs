using Entities.Entities;

namespace Domain.Contracts.Service;

public interface IVehicleService
{
    Task Insert(Vehicle vehicle);
    Task Update(Vehicle vehicle);
    Task Delete(Vehicle vehicle);
    Task GetById(Guid id);
    Task<IEnumerable<Vehicle>> Get();
}