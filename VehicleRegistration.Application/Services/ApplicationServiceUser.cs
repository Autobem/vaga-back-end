using System.Collections.Generic;
using VehicleRegistration.Application.DTO.DTO;
using VehicleRegistration.Application.Interfaces;
using VehicleRegistration.Domain.Core.Interfaces.Services;
using VehicleRegistration.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace VehicleRegistration.Application.Services
{
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IServiceUser _serviceUser;
        private readonly IMapperUser _mapperUser;

        public ApplicationServiceUser(IServiceUser ServiceUser
                                                 , IMapperUser MapperUser)
        {
            _serviceUser = ServiceUser;
            _mapperUser = MapperUser;
        }

        public void Add(UserDTO obj)
        {
            var objUser = _mapperUser.MapperToEntity(obj);
            _serviceUser.Add(objUser);
        }

        public void Dispose()
        {
            _serviceUser.Dispose();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var objUsers = _serviceUser.GetAll();
            return _mapperUser.MapperListUsers(objUsers);
        }

        public UserDTO GetById(int id)
        {
            var objUser = _serviceUser.GetById(id);
            return _mapperUser.MapperToDTO(objUser);
        }

        public void Remove(UserDTO obj)
        {
            var objUser = _mapperUser.MapperToEntity(obj);
            _serviceUser.Remove(objUser);
        }

        public void Update(UserDTO obj)
        {
            var objUser = _mapperUser.MapperToEntity(obj);
            _serviceUser.Update(objUser);
        }
    }
}
