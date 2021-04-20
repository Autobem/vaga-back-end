using System;

namespace Api.Domain.DTO.Pessoa
{
    public class PessoaDTOPutRequest
    {
        public int id { get; set; }
        public DateTime Atualizacao{ get; set; }
        public string Documento { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}