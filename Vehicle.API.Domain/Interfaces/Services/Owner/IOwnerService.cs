using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Domain.Dtos.Owner;

namespace Vehicles.API.Domain.Interfaces.Services.Owner
{
    public interface IOwnerService
    {
        Task<OwnerDto> Get(Guid id);
        Task<IEnumerable<OwnerDto>> GetAll();
        Task<OwnerDto> Post(OwnerDtoCreate owner);
        Task<OwnerDto> Put(OwnerDtoUpdate owner);
        Task<bool> Delete(Guid id);
    }
}
