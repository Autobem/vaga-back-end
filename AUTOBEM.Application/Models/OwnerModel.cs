using System;

namespace AUTOBEM.Application.Models
{
    public class OwnerModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Habilitacao { get; set; }
        public string Rg { get; set; }
    }
}
