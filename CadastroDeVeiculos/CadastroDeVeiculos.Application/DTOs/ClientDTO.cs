using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeVeiculos.Application.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        public NameDTO Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(11)]
        [MaxLength(11)]
        [DisplayName("Phone number")]
        public string PhoneNumber { get;  set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(10)]
        [MaxLength(100)]
        [DisplayName("E-mail")]
        public string Email { get;  set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(11)]
        [MaxLength(11)]
        [DisplayName("Document Cpf")]
        public string Document { get;  set; }


        public ICollection<VehicleDTO> Vehicles { get; set; }
    }
}
