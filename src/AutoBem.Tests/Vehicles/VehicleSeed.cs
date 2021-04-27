using AutoBem.Infrastructure.Clients.Entities;
using AutoBem.Infrastructure.Vehicles.Entities;
using BuildingBlocks.Test;
using System;

namespace AutoBem.Tests.Vehicle
{
    public class VehicleSeed : ISeed
    {

        public static VehicleEntity Vehicle01 { get; } = new VehicleEntity()
        {
            Id = Guid.Parse("c5a9f566-43e6-45f8-a268-3cd1d2a6d905"),
            Color = "red",
            LicensePlate = "ABD-1458",
            OwnerId = Guid.Parse("c5a9f566-43e6-45f8-a268-3cd1d2a6d905")
        };

        public static VehicleEntity Vehicle02 { get; } = new VehicleEntity()
        {
            Id = Guid.Parse("f7c9044f-de79-48c3-85dd-f81a722d45b2"),
            Color = "Blue",
            LicensePlate = "AFS-7895",
            OwnerId = Guid.Parse("f7c9044f-de79-48c3-85dd-f81a722d45b2")
        };

        public static ClientEntity Everton { get; } = new ClientEntity()
        {
            Id = Guid.Parse("c5a9f566-43e6-45f8-a268-3cd1d2a6d905"),
            Name = "Everton Schuster",
            CPF = "76711190084",
            Birthday = DateTimeOffset.Parse("30/09/1998")
        };

        public static ClientEntity Jean { get; } = new ClientEntity()
        {
            Id = Guid.Parse("f7c9044f-de79-48c3-85dd-f81a722d45b2"),
            Name = "Jean Schuster",
            CPF = "42383559032",
            Birthday = DateTimeOffset.Parse("11/05/2001")
        };

        public Object[] GetSeed()
        {
            return new Object[]
            {
                VehicleSeed.Everton,
                VehicleSeed.Jean,
                VehicleSeed.Vehicle01,
                VehicleSeed.Vehicle02
            };
        }
    }
}
