using AutoBem.Domain.Vehicles;
using AutoBem.Domain.Vehicles.Models;
using BuildingBlocks.Application.Queries.List;
using BuildingBlocks.Ioc.Attributes;

namespace AutoBem.Application.Vehicles.Queries.ListAll
{
    [Injectable]
    public class ListAllVehicleQueryHandler : ListAllQueryHandler<Vehicle, ListAllVehicleQuery, ListVehicleResult, IVehicleRepository>
    {
    }
}
