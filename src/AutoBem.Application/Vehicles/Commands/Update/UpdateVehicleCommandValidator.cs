using AutoBem.Domain.Clients;
using AutoBem.Domain.Vehicles;
using BuildingBlocks.Ioc.Attributes;
using FluentValidation;
using System;

namespace AutoBem.Application.Vehicles.Commands.Update
{
    [Injectable]
    public class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
    {
        public IVehicleRepository Repository { get; set; }

        public IClientRepository ClientRepository { get; set; }


        public UpdateVehicleCommandValidator(IVehicleRepository repository, IClientRepository clientRepository)
        {
            this.Repository = repository;
            this.ClientRepository = clientRepository;

            RuleFor(e => e.Id)
               .Must(ExistVehicle).WithMessage("Veículo não cadastrado.");

            RuleFor(e => e.Color)
                .NotEmpty().WithMessage("Cor é obrigatório.")
                .MinimumLength(3).WithMessage("Cor deve possuir mais de 3 caracteres.")
                .MaximumLength(50).WithMessage("Cor deve possuir menos de 50 caracteres.");

            RuleFor(e => e.LicensePlate)
                 .NotEmpty().WithMessage("Placa é obrigatório.")
                .MinimumLength(8).WithMessage("Placa deve possuir 8 caracteres.")
                .MaximumLength(8).WithMessage("Placa deve possuir 8 caracteres.");

            RuleFor(e => e.OwnerId)
                .NotEmpty().WithMessage("Proprietário é obrigatório.")
                .Must(ExistClient).WithMessage("Cliente não cadastrado.");
        }

        private bool ExistVehicle(Guid id)
        {
            return this.Repository.ExistById(id);
        }

        private bool ExistClient(Guid id)
        {
            return this.ClientRepository.ExistById(id);
        }
    }
}
