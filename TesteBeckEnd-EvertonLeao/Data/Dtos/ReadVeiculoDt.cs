using System;
using System.ComponentModel.DataAnnotations;

namespace TesteBeckEnd_EvertonLeao.Data.Dtos
{
    public class ReadVeiculoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Proprietario é obrigatório")]
        public string Proprietario { get; set; }

        [Required(ErrorMessage = "O campo Cpf é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O campo Ano Veiculo é obrigatório")]
        public int AnoVeiculo { get; set; }

        [Required(ErrorMessage = "O campo Cor é obrigatório")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "O campo Portas é obrigatório")]
        public int Portas { get; set; }

        [Required(ErrorMessage = "O campo Km é obrigatório")]
        public double Km { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
