using System.ComponentModel.DataAnnotations;

namespace DevAssuncaoCarros.API.ViewModels
{
    public class UsuarioViewModel
    {
        public class RegisterUserViewModel
        {
            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            public string Email { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            public string Password { get; set; }

            [Compare("Password", ErrorMessage = "As senhas não conferem")]
            public string ConfirmPassword { get; set; }
        }

        public class LoginUserViewModel
        {
            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [EmailAddress(ErrorMessage = "O campo {0} está em um formato inválido")]
            public string Email { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [StringLength(100, ErrorMessage = "O campo precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
            public string Password { get; set; }
        }
    }
}
