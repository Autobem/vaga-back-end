using AutoBem.Domain.Vehicles;
using AutoBem.Domain.Vehicles.Models;
using BuildingBlocks.Application.Queries.Details;
using BuildingBlocks.Ioc.Attributes;

namespace AutoBem.Application.Vehicles.Queries.Details
{
    [Injectable]
    public class DetailsVehicleQueryHandler : DetailsQueryHandler<Vehicle, DetailsVehicleQuery, DetailsVehicleResult, IVehicleRepository>
    {
    }
}
