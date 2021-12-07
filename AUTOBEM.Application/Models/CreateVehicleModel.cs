namespace AUTOBEM.Application.Models
{
    public class CreateVehicleModel
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AnoFabricacao { get; set; }
        public string Cor { get; set; }
        public int IdOwner { get; set; }
    }
}
