namespace DevAssuncaoCarros.Business.Models
{
    public class Endereco : Entidade
    {
        public string? Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Cep { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? UF { get; set; }
        public Proprietario? Proprietario { get; set; }
        public Guid ProprietarioId { get; set; }
    }
}