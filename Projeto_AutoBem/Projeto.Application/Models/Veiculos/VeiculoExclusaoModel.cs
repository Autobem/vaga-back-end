using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models.Veiculos
{
    public class VeiculoExclusaoModel
    {
        [Required(ErrorMessage = "Informe o id da veículo.")]
        public string IdVeiculo { get; set; }
    }
}
