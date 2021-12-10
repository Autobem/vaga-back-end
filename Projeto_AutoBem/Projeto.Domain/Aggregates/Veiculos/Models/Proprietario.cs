using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Aggregates.Veiculos.Models
{
    public class Proprietario
    {
        public int IdProprietario { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }

        public List<Veiculo> Veiculos { get; set; }
    }
}
