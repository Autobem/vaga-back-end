using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.Extentions;
using CadastroDeVeiculos.Domain.Validations.Resource;
using FluentValidation;

namespace CadastroDeVeiculos.Domain.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleOfProperty();
        }

        private void RuleOfProperty()
        {
            RuleFor(u => u.LoginData).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(u => u.LoginData).Length(5, 20).WithMessage(Message.MoreExpected.Description().FormatMessage("Login", "5 a 20"));

            RuleFor(u => u.Email).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(u => u.Email).EmailAddress().Length(10, 100)
                .WithMessage(Message.MoreExpected.Description().FormatMessage("Email", "10 a 100"));

            RuleFor(u => u.Password).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(u => u.Password).Length(6, 12).WithMessage(Message.MoreExpected.Description().FormatMessage("Password", "6 a 12"));

            RuleFor(u => u.Role).NotEmpty().WithMessage(Message.Required.Description());
        }
    }
}
