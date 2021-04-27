using AutoBem.Domain.Clients.Models;
using AutoBem.Domain.Vehicles.Models;
using AutoBem.Infrastructure.Clients.Entities;
using AutoBem.Infrastructure.Vehicles.Entities;
using BuildingBlocks.Infraestructure.Converters;
using BuildingBlocks.Ioc.Attributes;
using System;

namespace AutoBem.Infrastructure.Vehicles.Converters
{

    [Injectable]
    public class VehicleConvert : IMappedEntity<Vehicle, VehicleEntity>
    {
        [Inject]
        public IMappedEntity<Client, ClientEntity> ClientConvert { get; set; }

        public VehicleEntity ToEntity(Vehicle model)
        {
            return new VehicleEntity()
            {
                Id = model.Id ?? Guid.NewGuid(),
                Color = model.Color,
                LicensePlate = model.LicensePlate,
                OwnerId = model.OwnerId
            };
        }

        public Vehicle ToModel(VehicleEntity entity)
        {
            return new Vehicle()
            {
                Id = entity.Id,
                Color = entity.Color,
                LicensePlate = entity.LicensePlate,
                OwnerId = entity.OwnerId,
                Owner = this.ClientConvert?.ToModel(entity.Owner)
            };
        }
    }
}
