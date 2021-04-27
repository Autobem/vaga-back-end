using AutoBem.Domain.Clients;
using AutoBem.Domain.Vehicles;
using BuildingBlocks.Ioc.Attributes;
using FluentValidation;
using System;

namespace AutoBem.Application.Vehicles.Commands.Create
{
    [Injectable]
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public IVehicleRepository Repository { get; set; }
        public IClientRepository ClientRepository { get; set; }

        public CreateVehicleCommandValidator(IClientRepository clientRepository, IVehicleRepository repository)
        {
            this.Repository = repository;
            this.ClientRepository = clientRepository;

            RuleFor(e => e.Color)
                .NotEmpty().WithMessage("Cor é obrigatório.")
                .MinimumLength(3).WithMessage("Cor deve possuir mais de 3 caracteres.")
                .MaximumLength(50).WithMessage("Cor deve possuir menos de 50 caracteres.");

            RuleFor(e => e.LicensePlate)
                .NotEmpty().WithMessage("Placa é obrigatório.")
                .MinimumLength(8).WithMessage("Placa deve possuir 8 caracteres.")
                .MaximumLength(8).WithMessage("Placa deve possuir 8 caracteres.")
                .Must(NotExistLicensePlate).WithMessage("Placa já cadastrado.");


            RuleFor(e => e.OwnerId)
                .NotEmpty().WithMessage("Proprietário é obrigatório.")
                .Must(ExistClient).WithMessage("Cliente não cadastrado.");
        }

        private bool NotExistLicensePlate(string licensePlate)
        {
            return !this.Repository.ExistLicensePlate(licensePlate);
        }

        private bool ExistClient(Guid id)
        {
            return this.ClientRepository.ExistById(id);
        }
    }
}
