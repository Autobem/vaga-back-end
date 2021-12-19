using System.ComponentModel.DataAnnotations;

namespace CadastroDeVeiculos.Application.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is requirid")]
        [EmailAddress(ErrorMessage = "Email invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters log.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

    }
}
