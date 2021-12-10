using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Aggregates.Veiculos.Models
{
    public class Veiculo
    {
        public int IdVeiculo { get; set; }
        public int IdProprietario { get; set; }
        public string Renavam { get; set; }
        public string Placa { get; set; }
        public string Ano { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }

        public Proprietario Proprietario { get; set; }
        
    }
}
