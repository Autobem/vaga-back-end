using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Domain.Dtos.Owner;
using Vehicles.API.Domain.Entities;

namespace Vehicles.API.Domain.Dtos.Vehicle
{
    public class VehicleDtoCreate
    {
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Guid? OwnerId { get; set; }
        public OwnerDto? Owner { get; set; }
    }
}
