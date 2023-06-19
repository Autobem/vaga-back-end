using Domain.Enums;

namespace Domain.Dtos
{
    public class ProprietarioUpdateDto
    {
        public int ProprietarioId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public ETipoDocumento TipoDocumento { get; set; }
        public string Documento { get; set; }
    }
}
