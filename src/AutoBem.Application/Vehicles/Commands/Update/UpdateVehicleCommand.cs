using AutoBem.Domain.Vehicles.Models;
using BuildingBlocks.Application.Commands.Update;
using System;

namespace AutoBem.Application.Vehicles.Commands.Update
{
    public class UpdateVehicleCommand : UpdateCommand<Vehicle>
    {
        public String Color { get; set; }

        public String LicensePlate { get; set; }

        public Guid OwnerId { get; set; }

        public override Vehicle ToModel()
        {
            return new Vehicle()
            {
                Id = Id,
                Color = this.Color,
                LicensePlate = this.LicensePlate,
                OwnerId = this.OwnerId
            };
        }
    }
}
