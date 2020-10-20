using System.Collections.Generic;
using VehicleRegistration.Domain.Models;
using VehicleRegistration.Application.DTO.DTO;

namespace VehicleRegistration.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperClient
    {
        #region Mappers

        Client MapperToEntity(ClientDTO clientDTO);

        IEnumerable<ClientDTO> MapperListClients(IEnumerable<Client> clients);

        ClientDTO MapperToDTO(Client Client);

        #endregion

    }
}
