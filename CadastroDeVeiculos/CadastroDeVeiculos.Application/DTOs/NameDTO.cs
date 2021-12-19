using System.ComponentModel.DataAnnotations;

namespace CadastroDeVeiculos.Application.DTOs
{
    public class NameDTO
    {
        [Required(ErrorMessage = "Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string FirstName { get;  set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Lastname { get;  set; }
    }
}
