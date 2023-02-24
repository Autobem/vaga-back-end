using Car.Domain.DTOs.Car;
using Car.Domain.DTOs.Person;
using Car.Domain.Model.CarAggregate;
using Car.Domain.Model.PersonAggregate;
using Microsoft.EntityFrameworkCore;

namespace Car.DataBase.Repositories
{
    public class CarRepository : ICarRepository
    {
        public readonly ConnectionContext _context = new ConnectionContext();

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Add(Vehicle car)
        {
            _context.Car.Add(car);
            return Save();
        }

        public List<CarDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Car
                .Include(c => c.owner)
                .Skip((pageNumber - 1) * pageQuantity)
                .Take(pageQuantity)
                .Select(c => new CarDTO
                {
                    Id = c.id,
                    Name = c.name,
                    Owner = new PersonDTO
                    {
                        Id = c.owner.id,
                        Name = c.owner.name,
                        Email = c.owner.email,
                    }
                }
                )
                .ToList();
        }

        public Vehicle? Get(int id)
        {
            var car = _context.Car.Include(c => c.owner).FirstOrDefault(c => c.id == id);

            return car;
        }

        public bool UpdateCar(Vehicle car)
        {
            _context.Car.Update(car);
            return Save();
        }

        public bool DeleteCar(Vehicle car)
        {
            _context.Remove(car);
            return Save();
        }
    }
}
