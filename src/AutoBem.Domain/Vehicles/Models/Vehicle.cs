using AutoBem.Domain.Clients.Models;
using BuildingBlocks.Domain.Models;
using System;

namespace AutoBem.Domain.Vehicles.Models
{
    public class Vehicle : IModel
    {
        public Guid? Id { get; set; }

        public String Color { get; set; }

        public String LicensePlate { get; set; }

        public Guid OwnerId { get; set; }

        public Client Owner { get; set; }
    }
}
