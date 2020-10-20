using System.Collections.Generic;
using VehicleRegistration.Domain.Models;
using VehicleRegistration.Application.DTO.DTO;
using VehicleRegistration.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace VehicleRegistration.Infrastructure.CrossCutting.Adapter.Map
{
    public class MapperCar : IMapperCar
    {
        #region Properties

        List<CarDTO> carDTOs = new List<CarDTO>();

        #endregion

        #region methods

        public Car MapperToEntity(CarDTO carDTO)
        {
            Car car = new Car
            {
                Id = carDTO.Id,
                Name = carDTO.Name,
                Value = carDTO.Value,
                Brand = carDTO.Brand,
                Color = carDTO.Color,
                ClientId = carDTO.ClientId
            };

            return car;
        }

        public IEnumerable<CarDTO> MapperListCars(IEnumerable<Car> cars)
        {
            foreach (var item in cars)
            {
                CarDTO carDTO = new CarDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Value = item.Value,
                    Brand = item.Brand,
                    Color = item.Color,
                    ClientId = item.ClientId
                };

                carDTOs.Add(carDTO);
            }

            return carDTOs;
        }

        public CarDTO MapperToDTO(Car car)
        {
            CarDTO carDTO = new CarDTO
            {
                Id = car.Id,
                Name = car.Name,
                Value = car.Value,
                Brand = car.Brand,
                Color = car.Color,
                ClientId = car.ClientId
            };

            return carDTO;
        }

        #endregion
    }
}
