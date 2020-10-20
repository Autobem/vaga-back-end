using System.Collections.Generic;
using VehicleRegistration.Domain.Models;
using VehicleRegistration.Application.DTO.DTO;
using VehicleRegistration.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace VehicleRegistration.Infrastructure.CrossCutting.Adapter.Map
{
    public  class MapperClient : IMapperClient
    {
        #region properties

        List<ClientDTO> clientDTOs = new List<ClientDTO>();

        #endregion

        #region methods

        public Client MapperToEntity(ClientDTO clientDTO)
        {
            Client client = new Client
            {
                Id = clientDTO.Id,
                Name = clientDTO.Name,
                LastName = clientDTO.LastName,
                Email = clientDTO.Email
            };

            return client;
        }

        public IEnumerable<ClientDTO> MapperListClients(IEnumerable<Client> clients)
        {
            foreach (var item in clients)
            {
                ClientDTO clientDTO = new ClientDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    LastName = item.LastName,
                    Email = item.Email
                };

                clientDTOs.Add(clientDTO);
            }

            return clientDTOs;
        }

        public ClientDTO MapperToDTO(Client Client)
        {
            ClientDTO clientDTO = new ClientDTO
            {
                Id = Client.Id,
                Name = Client.Name,
                LastName = Client.LastName,
                Email = Client.Email
            };

            return clientDTO;
        }
        #endregion
    }
}
