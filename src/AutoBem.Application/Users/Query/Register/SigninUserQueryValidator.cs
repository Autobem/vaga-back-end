using AutoBem.Domain.Users;
using BuildingBlocks.Ioc.Attributes;
using FluentValidation;

namespace AutoBem.Application.Users.Query.Register
{
    [Injectable]
    public class SigninUserCommandValidator : AbstractValidator<SigninUserQuery>
    {
        [Inject]
        public IUserRepository Repository { get; set; }

        public SigninUserCommandValidator(IUserRepository repository)
        {
            Repository = repository;

            RuleFor(e => e.Username)
                .NotEmpty().WithMessage("Username é obrigatório.")
                .Must(ExistUserName).WithMessage("Usuário ou senha inválido.");

            RuleFor(e => e.Password)
                .NotEmpty().WithMessage("Senha é obrigatório.")
                .MinimumLength(3).WithMessage("Senha deve possuir mais de 3 caracteres.")
                .MaximumLength(16).WithMessage("Senha deve possuir menos de 16 caracteres.");
        }


        private bool ExistUserName(string username)
        {
            return Repository.ExistUserName(username);
        }
    }
}
