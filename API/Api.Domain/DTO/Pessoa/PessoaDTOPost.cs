using System;

namespace Api.Domain.DTO.Pessoa
{
    public class PessoaDTOPost
    {
        public int Id { get; set; }
        public DateTime Criacao{ get; set; }
        public string Documento { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}