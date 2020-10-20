using System.Collections.Generic;
using VehicleRegistration.Domain.Models;
using VehicleRegistration.Application.DTO.DTO;

namespace VehicleRegistration.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperUser
    {
        #region Mappers

        User MapperToEntity(UserDTO UserDTO);

        IEnumerable<UserDTO> MapperListUsers(IEnumerable<User> Users);

        UserDTO MapperToDTO(User User);

        #endregion

    }
}
