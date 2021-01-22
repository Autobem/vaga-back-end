using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Teste.Domain.Entities
{
    public class Proprietario : Entity
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }

        [JsonIgnore]
        public ICollection<Veiculo> Veiculos { get; set; }
    }
}
