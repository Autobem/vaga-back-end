using System.Text.Json.Serialization;

namespace Cars.Domain.DTOs
{
    public class PersonUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
