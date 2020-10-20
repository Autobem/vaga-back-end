using System.Collections.Generic;
using VehicleRegistration.Application.DTO.DTO;

namespace VehicleRegistration.Application.Interfaces
{
    public interface IApplicationServiceUser
    {
        void Add(UserDTO obj);

        UserDTO GetById(int id);

        IEnumerable<UserDTO> GetAll();

        void Update(UserDTO obj);

        void Remove(UserDTO obj);

        void Dispose();
    }
}
