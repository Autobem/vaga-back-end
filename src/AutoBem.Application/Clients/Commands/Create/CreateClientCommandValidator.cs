using AutoBem.Domain.Clients;
using BuildingBlocks.Domain.Generics.CPF;
using BuildingBlocks.Ioc.Attributes;
using FluentValidation;
using System;

namespace AutoBem.Application.Clients.Commands.Create
{
    [Injectable]
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public IClientRepository Repository { get; set; }

        public CreateClientCommandValidator(IClientRepository repository)
        {
            this.Repository = repository;

            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MinimumLength(3).WithMessage("Nome deve possuir mais de 3 caracteres.")
                .MaximumLength(255).WithMessage("Nome deve possuir menos de 255 caracteres.");

            RuleFor(e => e.CPF)
                .Must(e => CPF.IsCpf(e.Value)).WithMessage("CPF inválido")
                .Must(NotExistCPF).WithMessage("CPF já cadastrado.");

            RuleFor(e => e.Birthday)
                .NotEmpty().WithMessage("Informa Data de Nascimento.")
                .LessThan(e => DateTime.Now).WithMessage("Data de Nascimento não pode ser futura.");
        }

        private bool NotExistCPF(CPF cpf)
        {
            return !this.Repository.ExistCPF(cpf);
        }
    }
}
