using Domain.Models;

namespace Domain.Contracts.Service;

public interface IVehicleService
{
    Task<VehicleModel> Insert(VehicleModel vehicle);

    Task Update(VehicleModel vehicle);

    Task Delete(Guid id);

    Task<VehicleModel> GetById(Guid id);

    Task<List<VehicleModel>> Get();
}