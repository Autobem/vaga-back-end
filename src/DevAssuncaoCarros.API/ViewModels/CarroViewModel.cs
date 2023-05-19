using DevAssuncaoCarros.Business.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DevAssuncaoCarros.API.ViewModels
{
    public class CarroViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProprietarioId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 4)]
        public string? Fabricante { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string? ModeloCarro { get; set; }

        [Required]
        public int? AnoModelo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string? Categoria { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string? Cor { get; set; }

        [ScaffoldColumn(false)]
        [JsonIgnore]
        public Proprietario? Proprietario { get; set; }

    }
}