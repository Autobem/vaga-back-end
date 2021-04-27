using AutoBem.Domain.Vehicles.Models;
using BuildingBlocks.Application.Commands.Create;
using System;

namespace AutoBem.Application.Vehicles.Commands.Create
{
    public class CreateVehicleCommand : CreateCommand<Vehicle, CreateVehicleResult>
    {
        public String Color { get; set; }

        public String LicensePlate { get; set; }

        public Guid OwnerId { get; set; }


        public override Vehicle ToModel()
        {
            return new Vehicle()
            {
                Color = this.Color,
                LicensePlate = this.LicensePlate,
                OwnerId = this.OwnerId
            };
        }
    }
}
