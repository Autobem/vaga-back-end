using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models.Usuarios
{
    public class UsuarioExclusaoModel
    {
        [Required(ErrorMessage = "Informe o id do usuário.")]
        public string IdUsuario { get; set; }
    }
}
