using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.DTOs
{
    public class UsuarioDTO
    {
        public string IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
