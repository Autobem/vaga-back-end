using Projeto.Domain.Aggregates.Veiculos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.DTOs
{
    public class ProprietarioDTO
    {
        public string IdProprietario { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public List<Veiculo> Veiculos { get; set; }
    }
}
