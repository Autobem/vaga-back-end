using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Domain.Dtos.Vehicle;

namespace Vehicles.API.Domain.Dtos.Owner
{
    public class OwnerDtoUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
    }
}
