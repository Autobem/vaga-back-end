using FluentValidation;

namespace Teste.Domain.Entities.Validations
{
    public class ProprietarioValidation : AbstractValidator<Proprietario>
    {
        public ProprietarioValidation()
        {
            RuleFor(p => p.NomeCompleto)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
            RuleFor(p => p.Cpf.Length)
                .Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo CPF precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(p => CpfValidacao.Validar(p.Cpf))
                .Equal(true)
                .WithMessage("O CPF fornecido é inválido.");
        }
    }
}
