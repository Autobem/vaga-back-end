using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Domain.Entities
{
    public class Veiculo : Entity
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }

        public int? ProprietarioId { get; set; }
        public Proprietario Proprietario { get; set; }
    }
}
