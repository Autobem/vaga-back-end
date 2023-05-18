using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAssuncaoCarros.Business.Models
{
    public class Carro : Entidade
    {
        [ForeignKey("ProprietarioId")]
        public Guid ProprietarioId { get; set; }
        public string? Fabricante { get; set; }
        public string? ModeloCarro { get; set; }
        public int? AnoModelo { get; set; }
        public string? Categoria { get; set; }
        public string? Cor { get; set; }
        public Proprietario? Proprietario { get; set; }
        
    }
}
