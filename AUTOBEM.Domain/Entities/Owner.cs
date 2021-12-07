using System;

namespace AUTOBEM.Domain.Entities
{
    public class Owner : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string  Habilitacao { get; set; }
        public string Rg { get; set; }
    }
}
