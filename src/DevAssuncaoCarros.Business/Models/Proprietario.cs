using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAssuncaoCarros.Business.Models
{
    public class Proprietario : Entidade
    {
        public Guid EnderecoId { get; set; }
        public string? Nome { get; set; }
        public string? Documento { get; set; }
        public string? CNH { get; set; }
        public Endereco? Endereco { get; set; }
        public virtual IEnumerable<Carro>? Carros { get; set; }

    }
}
