using Projeto.Domain.Aggregates.Veiculos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.DTOs
{
    public class VeiculoDTO
    {
        public string IdVeiculo { get; set; }
        public string Renavam { get; set; }
        public string Placa { get; set; }
        public string Ano { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }        
    }
}
