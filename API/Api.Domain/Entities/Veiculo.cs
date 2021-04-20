namespace Api.Domain.Entities
{
    public partial class Veiculo : BaseEntity
    {
        public string Nome { get; set; }
        public short Modelo { get; set; }
        public short Ano { get; set; }
        public string Placa { get; set; }
        public byte? Portas { get; set; }
        public int? Km { get; set; }
        public string Cambio { get; set; }
        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}