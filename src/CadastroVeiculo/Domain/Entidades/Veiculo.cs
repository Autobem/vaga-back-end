using Domain.Enums;

namespace Domain.Entidades
{
    public class Veiculo
    {
        public int VeiculoId { get; set; }
        public int ProprietarioId { get; set; }
        public virtual Proprietario Proprietario { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public long Renavam { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public EMontadora Montadora { get; set; }
    }
}
