namespace AUTOBEM.Application.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AnoFabricacao { get; set; }
        public string Cor { get; set; }
        public int IdOwner { get; set; }
    }
}
