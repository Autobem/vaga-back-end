using Car.Domain.DTOs.Person;
using System.Text.Json.Serialization;

namespace APICars.Domain.DTOs.Car
{
    public class CarUpdateDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Owner_id { get; set; }

        [JsonIgnore]
        public DateTime created_on { get; set; }
    }
}
