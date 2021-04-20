using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public partial class Pessoa : BaseEntity
    {
        public Pessoa()
        {
            Veiculo = new HashSet<Veiculo>();
        }

        public string Documento { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        public virtual ICollection<Veiculo> Veiculo { get; set; }
    }
}