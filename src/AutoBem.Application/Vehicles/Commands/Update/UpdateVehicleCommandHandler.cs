using AutoBem.Domain.Vehicles;
using AutoBem.Domain.Vehicles.Models;
using BuildingBlocks.Application.Commands.Update;
using BuildingBlocks.Ioc.Attributes;

namespace AutoBem.Application.Vehicles.Commands.Update
{
    [Injectable]
    public class UpdateVehicleCommandHandler : UpdateCommandHandler<Vehicle, UpdateVehicleCommand, IVehicleRepository>
    {
    }
}
