using AutoBem.Domain.Clients;
using BuildingBlocks.Ioc.Attributes;
using FluentValidation;
using System;

namespace AutoBem.Application.Clients.Queries.Details
{
    [Injectable]
    public class DetailsClientQueryValidator : AbstractValidator<DetailsClientQuery>
    {
        public IClientRepository Repository { get; set; }

        public DetailsClientQueryValidator(IClientRepository repository)
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
