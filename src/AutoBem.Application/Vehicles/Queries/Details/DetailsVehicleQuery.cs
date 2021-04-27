using AutoBem.Domain.Vehicles.Models;
using BuildingBlocks.Application.Queries.Details;
using System;

namespace AutoBem.Application.Vehicles.Queries.Details
{
    public class DetailsVehicleQuery : DetailsQuery<Vehicle, DetailsVehicleResult>
    {
        public DetailsVehicleQuery(Guid id) : base(id)
        {
        }
    }
}
