using CadastroDeVeiculos.Domain.Extentions;
using CadastroDeVeiculos.Domain.Validations.Resource;
using CadastroDeVeiculos.Domain.ValueObject;
using FluentValidation;

namespace CadastroDeVeiculos.Domain.Validations.ValueObject
{
    public class NameValidation : AbstractValidator<Name>
    {
        public NameValidation()
        {
            RuleOfProperty();
        }

        private void RuleOfProperty()
        {
            RuleFor(n => n.FirstName).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(n => n.FirstName)
                .Length(3, 100).WithMessage(Message.MoreExpected.Description().FormatMessage("Nome", "3 a 100"));

            RuleFor(n=> n.Lastname).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(n => n.Lastname)
                .Length(3, 100).WithMessage(Message.MoreExpected.Description().FormatMessage("sobrenome", "3 a 100"));
        }
    }
}
