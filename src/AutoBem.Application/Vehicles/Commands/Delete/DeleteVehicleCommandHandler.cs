using AutoBem.Domain.Vehicles;
using AutoBem.Domain.Vehicles.Models;
using BuildingBlocks.Application.Commands.Delete;
using BuildingBlocks.Ioc.Attributes;

namespace AutoBem.Application.Vehicles.Commands.Delete
{
    [Injectable]
    public class DeleteVehicleCommandHandler : DeleteCommandHandler<Vehicle, DeleteVehicleCommand, IVehicleRepository>
    {
    }
}
