using AutoBem.Domain.Vehicles.Models;
using BuildingBlocks.Domain;
using System;

namespace AutoBem.Domain.Vehicles
{
    public interface IVehicleRepository : ICrudRepository<Vehicle>
    {
        bool ExistLicensePlate(string licensePlate);

        bool OwnerHasVehicle(Guid id);
    }
}
