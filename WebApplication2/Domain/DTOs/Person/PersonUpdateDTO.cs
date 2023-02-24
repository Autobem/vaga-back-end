using System.Text.Json.Serialization;

namespace Car.Domain.DTOs.Person
{
    public class PersonUpdateDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public DateTime created_on { get; set; }
    }
}
