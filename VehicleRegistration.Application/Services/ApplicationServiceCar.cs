using System;
using System.Collections.Generic;
using VehicleRegistration.Application.DTO.DTO;
using VehicleRegistration.Application.Interfaces;
using VehicleRegistration.Domain.Core.Interfaces.Services;
using VehicleRegistration.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace VehicleRegistration.Application.Services
{
    public class ApplicationServiceCar : IDisposable, IApplicationServiceCar
    {
        private readonly IServiceCar _serviceCar;
        private readonly IMapperCar _mapperCar;

        public ApplicationServiceCar(IServiceCar ServiceCar
                                         , IMapperCar MapperCar)
        {
            _serviceCar = ServiceCar;
            _mapperCar = MapperCar;
        }

        public void Add(CarDTO obj)
        {
            var objCar = _mapperCar.MapperToEntity(obj);
            _serviceCar.Add(objCar);
        }

        public void Dispose()
        {
            _serviceCar.Dispose();
        }

        public IEnumerable<CarDTO> GetAll()
        {
            var objCars = _serviceCar.GetAll();
            return _mapperCar.MapperListCars(objCars);
        }

        public CarDTO GetById(int id)
        {
            var objCar = _serviceCar.GetById(id);
            return _mapperCar.MapperToDTO(objCar);
        }

        public void Remove(CarDTO obj)
        {
            var objCar = _mapperCar.MapperToEntity(obj);
            _serviceCar.Remove(objCar);
        }

        public void Update(CarDTO obj)
        {
            var objCar = _mapperCar.MapperToEntity(obj);
            _serviceCar.Update(objCar);
        }
    }
}
