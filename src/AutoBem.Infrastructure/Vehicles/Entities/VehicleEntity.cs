using AutoBem.Infrastructure.Clients.Entities;
using BuildingBlocks.Infraestructure.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace AutoBem.Infrastructure.Vehicles.Entities
{
    public class VehicleEntity : CommonEntity
    {
        [StringLength(50)]
        public String Color { get; set; }

        [StringLength(8)]
        public String LicensePlate { get; set; }

        public Guid OwnerId { get; set; }

        public ClientEntity Owner { get; set; }
    }
}
