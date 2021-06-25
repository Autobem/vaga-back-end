using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.API.Domain.Dtos.User;

namespace Vehicles.API.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> Post(UserDtoCreate owner);
        Task<UserDto> Put(UserDto owner);
        Task<bool> Delete(Guid id);
    }
}
