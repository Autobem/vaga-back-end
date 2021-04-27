using AutoBem.Domain.Vehicles.Models;
using BuildingBlocks.Application.Queries.Details;
using System;

namespace AutoBem.Application.Vehicles.Queries.Details
{
    public class DetailsVehicleResult : DetailsResult<Vehicle>
    {
        public Guid Id { get; set; }

        public String Color { get; set; }

        public String LicensePlate { get; set; }

        public Guid OwnerId { get; set; }

        public String OwnerName { get; set; }

        public override DetailsResult<Vehicle> FromModel(Vehicle Vehicle)
        {
            if (Vehicle is null)
            {
                return null;
            }

            this.Id = Vehicle.Id.Value;
            this.Color = Vehicle.Color;
            this.LicensePlate = Vehicle.LicensePlate;
            this.OwnerId = Vehicle.OwnerId;
            this.OwnerName = Vehicle.Owner?.Name;

            return this;
        }
    }
}
