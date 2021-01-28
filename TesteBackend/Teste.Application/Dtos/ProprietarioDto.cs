using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Teste.Application.Dtos
{
    public class ProprietarioDto
    {
        [Key]
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }

        [JsonIgnore]
        public ICollection<VeiculoDto> VeiculosDto { get; set; }
    }
}
