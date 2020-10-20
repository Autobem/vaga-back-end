using System;

namespace VehicleRegistration.Domain.Models
{
   public class Client : Base
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Active { get; set; }
    }
}
