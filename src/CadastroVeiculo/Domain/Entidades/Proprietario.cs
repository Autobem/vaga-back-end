using Domain.Enums;

namespace Domain.Entidades
{
    public class Proprietario
    {
        public int ProprietarioId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public ETipoDocumento TipoDocumento { get; set; }
        public string Documento { get; set; }

        public IEnumerable<Veiculo> Veiculos { get; set; }
    }
}
