using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Domain.Dtos.Vehicle;
using Vehicles.API.Domain.Entities;

namespace Vehicles.API.Domain.Dtos.Owner
{
    public class OwnerDtoCreate
    {
        public string Name { get; set; }
        //public List<VehicleDtoUpdate>? Vehicles { get; set; }
    }
}
