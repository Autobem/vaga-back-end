using Car.Domain.DTOs.Car;
using Car.Domain.Model.PersonAggregate;

namespace Car.Domain.Model.CarAggregate
{
    public interface ICarRepository
    {
        bool Add(Vehicle car);
        List<CarDTO> Get(int pageNumber, int pageQuantity);
        Vehicle? Get(int id);
        bool UpdateCar(Vehicle car);
        bool DeleteCar(Vehicle car);
    }
}
