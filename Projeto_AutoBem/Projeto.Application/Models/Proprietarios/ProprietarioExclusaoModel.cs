using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models.Proprietarios
{
    public class ProprietarioExclusaoModel
    {
        [Required(ErrorMessage = "Informe o id proprietário.")]
        public string IdProprietario { get; set; }
    }
}
