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
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }

        public int? ProprietarioDtoId { get; set; }
        public ProprietarioDto ProprietarioDto { get; set; }
    }
}
