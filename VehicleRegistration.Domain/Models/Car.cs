using System;

namespace VehicleRegistration.Domain.Models
{
    public class Car : Base
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Value { get; set; }
        public string Color { get; set; }
        public int ClientId { get; set; }
        public DateTime DateRegister { get; set; }
        public virtual Client Client { get; set; }
    }
}
