using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.API.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Owner? Owner { get; set; }
    }
}
