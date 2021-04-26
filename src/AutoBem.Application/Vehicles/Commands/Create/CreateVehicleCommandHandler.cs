using AutoBem.Domain.Vehicles;
using AutoBem.Domain.Vehicles.Models;
using BuildingBlocks.Application.Commands.Create;
using BuildingBlocks.Ioc.Attributes;

namespace AutoBem.Application.Vehicles.Commands.Create
{
    [Injectable]
    public class CreateVehicleCommandHandler : CreateCommandHandler<Vehicle, CreateVehicleCommand, CreateVehicleResult, IVehicleRepository>
    {
    }
}
