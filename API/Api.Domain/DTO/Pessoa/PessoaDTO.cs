using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTO.Pessoa
{
    public class PessoaDTO
    {
        [Required(ErrorMessage="Documento CPF ou CNPJ obrigatório")]
        [StringLength(14, ErrorMessage="Deve ter no máximo {1} caracteres")]
        public string Documento { get; set; }

        [Required(ErrorMessage="Nome é obrigatório")]
        [StringLength(70, ErrorMessage="Nome deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage="Cidade é obrigatório")]
        [StringLength(50, ErrorMessage="Cidade deve ter no máximo {1} caracteres")]
        public string Cidade { get; set; }
        
        [Required(ErrorMessage="Uf é obrigatório")]
        [StringLength(2, ErrorMessage="Uf deve ter no máximo {1} caracteres")]
        public string Uf { get; set; }
    }
}