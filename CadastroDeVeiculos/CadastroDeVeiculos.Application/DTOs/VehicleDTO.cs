using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeVeiculos.Application.DTOs
{
    public class VehicleDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(2)]
        [MaxLength(50)]
        [DisplayName("Model")]
        public string ModelName { get;  set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(2)]
        [MaxLength(70)]
        [DisplayName("Brand")]
        public string Brand { get;  set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(4)]
        [DisplayName("Year of manufacturer")]
        public int YearOfManufacturer { get;  set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(7)]
        [MaxLength(7)]
        [DisplayName("Plate")]
        public string Plate { get;  set; }


        public int ClientId { get; set; }
        public ClientDTO Client { get; set; }
    }
}
