using CadastroDeVeiculos.Application.DTOs.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeVeiculos.Application.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Required")]
        [MinLength(5)]
        [MaxLength(20)]
        [DisplayName("Login")]
        public string LoginData { get;  set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(10)]
        [MaxLength(100)]
        [DisplayName("E-mail")]
        public string Email { get;  set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(6)]
        [MaxLength(12)]
        [DisplayName("Password")]
        public string Password { get;  set; }

        [Required(ErrorMessage = "Required")]
        public RoleDTO Role { get;  set; }
    }
}
