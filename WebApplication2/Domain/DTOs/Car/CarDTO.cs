using Car.Domain.DTOs.Person;

namespace Car.Domain.DTOs.Car
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PersonDTO Owner { get; set; }
    }
}
