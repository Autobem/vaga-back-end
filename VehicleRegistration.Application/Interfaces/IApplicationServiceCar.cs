using System.Collections.Generic;
using VehicleRegistration.Application.DTO.DTO;

namespace VehicleRegistration.Application.Interfaces
{
    public interface IApplicationServiceCar
    {
        void Add(CarDTO obj);

        CarDTO GetById(int id);

        IEnumerable<CarDTO> GetAll();

        void Update(CarDTO obj);

        void Remove(CarDTO obj);

        void Dispose();
    }
}
