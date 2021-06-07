using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.API.Domain.Entities
{
    public class Owner : BaseEntity
    {
        public string Name { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
