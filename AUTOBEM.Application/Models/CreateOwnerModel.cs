using System;

namespace AUTOBEM.Application.Models
{
    public class CreateOwnerModel
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Habilitacao { get; set; }
        public string Rg { get; set; }
    }
}
