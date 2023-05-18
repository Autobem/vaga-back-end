using DevAssuncaoCarros.Business.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DevAssuncaoCarros.API.ViewModels
{
    public class ProprietarioViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EnderecoId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.",MinimumLength =3)]
        public string? Nome { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        [JsonIgnore]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 11)]
        public string? Documento { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter {1} caracteres.")]
        public string? CNH { get; set; }

        public Endereco? Endereco { get; set; }
        public virtual IEnumerable<CarroViewModel>? Carros { get; set; }
    }
}
