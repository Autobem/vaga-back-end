namespace VehicleRegistration.Application.DTO.DTO
{
    public class CarDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Value { get; set; }
        public string Color { get; set; }
        public int ClientId { get; set; }
    }
}
