using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Domain.Dtos.Vehicle;

namespace Vehicles.API.Domain.Interfaces.Services.Vehicle
{
    public interface IVehicleService
    {
        Task<VehicleDto> Get(Guid id);
        Task<IEnumerable<VehicleDto>> GetAll();
        Task<VehicleDto> Post(VehicleDtoCreate vehicle);
        Task<VehicleDto> Put(VehicleDtoUpdate vehicle);
        Task<bool> Delete(Guid id);
    }
}
