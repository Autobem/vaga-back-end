using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CadastroDeVeiculos.Application.DTOs.ValueObject
{
    public class NameDTO
    {
        [Required(ErrorMessage = "Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Lastname")]
        public string Lastname { get; set; }
    }
}
