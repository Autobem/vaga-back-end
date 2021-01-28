using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Domain.Entities.Validations
{
    public class VeiculoValidation : AbstractValidator<Veiculo>
    {
        public VeiculoValidation()
        {
            RuleFor(v => v.Nome)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(1, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
            RuleFor(v => v.Marca)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(1, 20)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
            RuleFor(v => v.Modelo)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(1, 20)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
            RuleFor(v => v.Cor)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(1, 20)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
