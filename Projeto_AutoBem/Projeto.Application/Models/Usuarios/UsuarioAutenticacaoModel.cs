using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models.Usuarios
{
    public class UsuarioAutenticacaoModel
    {
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        [Required(ErrorMessage = "Informe o email do usuário.")]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe a senha do usuário.")]
        public string Senha { get; set; }
    }
}
