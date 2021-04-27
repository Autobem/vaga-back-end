using AutoBem.Domain.Vehicles.Models;
using BuildingBlocks.Application.Queries.List;
using System;

namespace AutoBem.Application.Vehicles.Queries.ListAll
{
    public class ListVehicleResult : ListResult<Vehicle>
    {
        public Guid Id { get; set; }

        public String Color { get; set; }

        public String LicensePlate { get; set; }

        public Guid OwnerId { get; set; }

        public String OwnerName { get; set; }

        public override ListResult<Vehicle> FromModel(Vehicle Vehicle)
        {
            this.Id = Vehicle.Id.Value;
            this.Color = Vehicle.Color;
            this.LicensePlate = Vehicle.LicensePlate;
            this.OwnerId = Vehicle.OwnerId;
            this.OwnerName = Vehicle.Owner?.Name;

            return this;
        }
    }
}
