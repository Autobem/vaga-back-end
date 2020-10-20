using System.Collections.Generic;
using VehicleRegistration.Domain.Models;
using VehicleRegistration.Application.DTO.DTO;

namespace VehicleRegistration.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperCar
    {
        #region Interfaces Mappers
        Car MapperToEntity(CarDTO produtoDTO);

        IEnumerable<CarDTO> MapperListCars(IEnumerable<Car> cars);

        CarDTO MapperToDTO(Car car);

        #endregion
    }
}
