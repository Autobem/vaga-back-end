using System.Collections.Generic;
using VehicleRegistration.Application.DTO.DTO;
using VehicleRegistration.Application.Interfaces;
using VehicleRegistration.Domain.Core.Interfaces.Services;
using VehicleRegistration.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace VehicleRegistration.Application.Services
{
    public class ApplicationServiceClient : IApplicationServiceClient
    {
        private readonly IServiceClient _serviceClient;
        private readonly IMapperClient _mapperClient;

        public ApplicationServiceClient(IServiceClient ServiceClient
                                                 , IMapperClient MapperClient)
        {
            _serviceClient = ServiceClient;
            _mapperClient = MapperClient;
        }

        public void Add(ClientDTO obj)
        {
            var objClient = _mapperClient.MapperToEntity(obj);
            _serviceClient.Add(objClient);
        }

        public void Dispose()
        {
            _serviceClient.Dispose();
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            var objClients = _serviceClient.GetAll();
            return _mapperClient.MapperListClients(objClients);
        }

        public ClientDTO GetById(int id)
        {
            var objclient = _serviceClient.GetById(id);
            return _mapperClient.MapperToDTO(objclient);
        }

        public void Remove(ClientDTO obj)
        {
            var objClient = _mapperClient.MapperToEntity(obj);
            _serviceClient.Remove(objClient);
        }

        public void Update(ClientDTO obj)
        {
            var objClient = _mapperClient.MapperToEntity(obj);
            _serviceClient.Update(objClient);
        }
    }
}
