namespace Autobem.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string Placa { get; set; }

        public Proprietario Proprietario { get; set; }
        public Cor Cor { get; set; }
    }
}
