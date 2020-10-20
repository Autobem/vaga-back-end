using System.Collections.Generic;
using VehicleRegistration.Domain.Models;
using VehicleRegistration.Application.DTO.DTO;
using VehicleRegistration.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace VehicleRegistration.Infrastructure.CrossCutting.Adapter.Map
{
    public  class MapperUser : IMapperUser
    {
        #region properties

        List<UserDTO> userDTOs = new List<UserDTO>();

        #endregion

        #region methods

        public User MapperToEntity(UserDTO userDTO)
        {
            User user = new User
            {
                Id = userDTO.Id,
                Login = userDTO.Login,
                Password = userDTO.Password
            };

            return user;
        }

        public IEnumerable<UserDTO> MapperListUsers(IEnumerable<User> users)
        {
            foreach (var item in users)
            {
                UserDTO userDTO = new UserDTO
                {
                    Id = item.Id,
                    Login = item.Login,
                    Password = item.Password
                };

                userDTOs.Add(userDTO);
            }

            return userDTOs;
        }

        public UserDTO MapperToDTO(User User)
        {
            UserDTO userDTO = new UserDTO
            {
                Id = User.Id,
                Login = User.Login,
                Password = User.Password
            };

            return userDTO;
        }
        #endregion
    }
}
