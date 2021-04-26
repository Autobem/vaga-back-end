using AutoBem.Domain.Clients;
using AutoBem.Domain.Vehicles;
using BuildingBlocks.Ioc.Attributes;
using FluentValidation;
using System;

namespace AutoBem.Application.Clients.Commands.Delete
{
    [Injectable]
    public class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
    {
        public IClientRepository Repository { get; set; }

        public IVehicleRepository VehicleRepository { get; set; }

        public DeleteClientCommandValidator(IClientRepository repository, IVehicleRepository vehicleRepository)
        {
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.VehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));

            RuleFor(e => e.Id)
                   .Must(ExistClient).WithMessage("Cliente não cadastrado.")
                   .Must(ClientDontHasVehicle).WithMessage("Cliente possui veicúlo cadastrado.");
        }

        private bool ExistClient(Guid id)
        {
            return this.Repository.ExistById(id);
        }

        private bool ClientDontHasVehicle(Guid id)
        {
            return !this.VehicleRepository.OwnerHasVehicle(id);
        }
    }
}
