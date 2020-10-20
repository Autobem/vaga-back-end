using System;

namespace VehicleRegistration.Domain.Models
{
    public class User : Base
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateRegister { get; set; }
    }
}
