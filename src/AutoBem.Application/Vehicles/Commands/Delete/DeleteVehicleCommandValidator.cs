using AutoBem.Domain.Vehicles;
using BuildingBlocks.Ioc.Attributes;
using FluentValidation;
using System;

namespace AutoBem.Application.Vehicles.Commands.Delete
{
    [Injectable]
    public class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand>
    {
        public IVehicleRepository Repository { get; set; }

        public DeleteVehicleCommandValidator(IVehicleRepository repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));

            RuleFor(e => e.Id)
                   .Must(ExistVehicle).WithMessage("Veículo não cadastrado.");
        }

        private bool ExistVehicle(Guid id)
        {
            return this.Repository.ExistById(id);
        }

    }
}
