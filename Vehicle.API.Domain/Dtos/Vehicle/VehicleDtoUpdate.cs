using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.API.Domain.Dtos.Vehicle
{
    public class VehicleDtoUpdate
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Guid? OwnerId { get; set; }
    }
}
