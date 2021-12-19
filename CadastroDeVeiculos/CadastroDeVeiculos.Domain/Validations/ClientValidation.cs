using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.Extentions;
using CadastroDeVeiculos.Domain.Validations.Resource;
using FluentValidation;

namespace CadastroDeVeiculos.Domain.Validations
{
    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
        {
            RuleOfProperty();
        }

        private void RuleOfProperty()
        {

            RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(c => c.PhoneNumber).Length(11)
                .WithMessage("Número de celular deve ter 11 caracteres");

            RuleFor(c => c.Email).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(c => c.Email).EmailAddress().Length(10,100)
                .WithMessage(Message.MoreExpected.Description().FormatMessage("Email", "10 a 100"));

            RuleFor(c => c.Document).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(c => c.Document).Length(11)
                .WithMessage("Cpf deve ter 11 caracteres.");
        }
    }
}
