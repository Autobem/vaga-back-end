namespace Autobem.Application.DTO
{
    public class VeiculoDTO
    {
        public int ID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public ProprietarioDTO Proprietario { get; set; }
        public CorDTO Cor { get; set; }

    }
}
