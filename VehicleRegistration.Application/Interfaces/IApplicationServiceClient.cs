using System.Collections.Generic;
using VehicleRegistration.Application.DTO.DTO;

namespace VehicleRegistration.Application.Interfaces
{
    public interface IApplicationServiceClient
    {
        void Add(ClientDTO obj);

        ClientDTO GetById(int id);

        IEnumerable<ClientDTO> GetAll();

        void Update(ClientDTO obj);

        void Remove(ClientDTO obj);

        void Dispose();
    }
}
