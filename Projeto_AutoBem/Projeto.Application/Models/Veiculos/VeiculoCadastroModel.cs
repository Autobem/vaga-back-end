using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models.Veiculos
{
    public class VeiculoCadastroModel
    {
        [Required(ErrorMessage = "Informe o id do proprietário.")]
        public string IdProprietario { get; set; }

        [StringLength(11, ErrorMessage = "Por favor, informe exatamente {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o renavam do veículo.")]
        public string Renavam { get; set; }

        [StringLength(7, ErrorMessage = "Por favor, informe exatamente {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a placa do veículo.")]
        public string Placa { get; set; }

        [StringLength(4, ErrorMessage = "Por favor, informe exatamente {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o ano do veículo.")]
        public string Ano { get; set; }


        [Required(ErrorMessage = "Por favor, informe o modelo do veículo.")]
        public string Modelo { get; set; }


        [Required(ErrorMessage = "Por favor, informe o tipo do veículo.")]
        public string Tipo { get; set; }
    }
}
