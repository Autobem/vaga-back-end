using AutoBem.Domain.Clients;
using BuildingBlocks.Ioc.Attributes;
using FluentValidation;
using System;

namespace AutoBem.Application.Clients.Commands.Delete
{
    [Injectable]
    public class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
    {
        public IClientRepository Repository { get; set; }

        public DeleteClientCommandValidator(IClientRepository repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));

            RuleFor(e => e.Id)
                   .Must(ExistClient).WithMessage("Cliente não cadastrado.");
        }

        private bool ExistClient(Guid id)
        {
            return this.Repository.ExistById(id);
        }

    }
}
