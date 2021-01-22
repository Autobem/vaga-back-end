using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Teste.Application.Dtos
{
    public class VeiculoDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campos {0} é obrigatório.")]
        [MaxLength(50, ErrorMessage = "Texto muito grande.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campos {0} é obrigatório.")]
        [MaxLength(20, ErrorMessage = "Texto muito grande.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campos {0} é obrigatório.")]
        [MaxLength(20, ErrorMessage = "Texto muito grande.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campos {0} é obrigatório.")]
        [MaxLength(20, ErrorMessage = "Texto muito grande.")]
        public string Cor { get; set; }

        public int? ProprietarioDtoId { get; set; }
        public ProprietarioDto ProprietarioDto { get; set; }
    }
}
