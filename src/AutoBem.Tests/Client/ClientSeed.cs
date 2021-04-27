using AutoBem.Infrastructure.Clients.Entities;
using AutoBem.Infrastructure.Vehicles.Entities;
using BuildingBlocks.Test;
using System;

namespace AutoBem.Tests.Client
{
    public class ClientSeed : ISeed
    {

        public static ClientEntity Everton { get; } = new ClientEntity()
        {
            Id = Guid.Parse("c5a9f566-43e6-45f8-a268-3cd1d2a6d901"),
            Name = "Everton Schuster",
            CPF = "76711190084",
            Birthday = DateTimeOffset.Parse("30/09/1998")
        };

        public static ClientEntity Jean { get; } = new ClientEntity()
        {
            Id = Guid.Parse("f7c9044f-de79-48c3-85dd-f81a722d45b0"),
            Name = "Jean Schuster",
            CPF = "42383559032",
            Birthday = DateTimeOffset.Parse("11/05/2001")
        };

        public static VehicleEntity Vehicle { get; } = new VehicleEntity()
        {
            Id = Guid.Parse("f7c9044f-de79-48c3-85dd-f81a722d45b0"),
            Color = "Blue",
            LicensePlate = "ASD-7653",
            OwnerId = Guid.Parse("f7c9044f-de79-48c3-85dd-f81a722d45b0"),
        };

        public object[] GetSeed()
        {
            return new object[]
            {
                ClientSeed.Everton,
                ClientSeed.Jean,
                ClientSeed.Vehicle
            };
        }
    }
}
