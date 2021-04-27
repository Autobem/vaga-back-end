using FluentValidation;
using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Service.Validators
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(c => c.Brand)
                .NotEmpty().WithMessage("Please enter the maker's name.")
                .NotNull().WithMessage("Please enter the maker's name.");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("Please enter the city.")
                .NotNull().WithMessage("Please enter the city.");

            RuleFor(c => c.Color)
                .NotEmpty().WithMessage("Please enter the color.")
                .NotNull().WithMessage("Please enter the color.");

            RuleFor(c => c.FabricationYear)
                .NotEmpty().WithMessage("Please enter the fabrication year.")
                .NotNull().WithMessage("Please enter the fabrication year.");

            RuleFor(c => c.OwnerId)
                .NotEmpty().WithMessage("Please enter the owner.")
                .NotNull().WithMessage("Please enter the owner.");

            RuleFor(c => c.Plate)
                .NotEmpty().WithMessage("Please enter the plate's number.")
                .NotNull().WithMessage("Please enter the plate's number.");

            RuleFor(c => c.UF)
                .NotEmpty().WithMessage("Please enter the UF.")
                .NotNull().WithMessage("Please enter the UF.");
        }
    }
}
