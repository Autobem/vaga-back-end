using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models.Proprietarios
{
    public class ProprietarioEdicaoModel
    {
        [Required(ErrorMessage = "Informe o id proprietário.")]
        public string IdProprietario { get; set; }

        [StringLength(11, ErrorMessage = "Por favor, informe exatamente {1} caracteres.")]
       // [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Informe um cpf válido.")]
        [Required(ErrorMessage = "Por favor, informe o cpf do proprietário.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do proprietário.")]
        public string Nome { get; set; }
    }
}
