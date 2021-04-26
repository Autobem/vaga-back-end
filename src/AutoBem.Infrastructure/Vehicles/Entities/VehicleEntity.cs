using AutoBem.Infrastructure.Clients.Entities;
using BuildingBlocks.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace AutoBem.Infrastructure.Vehicles.Entities
{
    [Index(nameof(LicensePlate), Name = "Index_LicensePlate")]
    [Index(nameof(OwnerId), Name = "Index_OwnerId")]
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
