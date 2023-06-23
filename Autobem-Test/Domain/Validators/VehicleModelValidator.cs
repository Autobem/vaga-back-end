using Domain.Models;
using Domain.Utils;
using FluentValidation;

namespace Domain.Validators;

public class VehicleModelValidator : AbstractValidator<VehicleModel>
{
    public VehicleModelValidator()
    {
        RuleFor(v => v.Plate)
            .NotEmpty().WithMessage("Invalid Plate: field cannot be empty");
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Invalid Name: field cannot be empty");
        RuleFor(v => v.Brand)
            .NotEmpty().WithMessage("Invalid Brand: field cannot be empty");
        RuleFor(v => v.Color)
            .NotEmpty().WithMessage("Invalid Color: field cannot be empty");
        RuleFor(v => v.City)
            .NotEmpty().WithMessage("Invalid City: field cannot be empty");
        RuleFor(v => v.State)
            .NotEmpty().WithMessage("Invalid State: field cannot be empty");
        RuleFor(v => v.Year)
            .NotEmpty().WithMessage("Invalid Year: field cannot be empty")
            .Must(y => y.Length == 4)
                .When(y => !string.IsNullOrWhiteSpace(y.Year))
                .WithMessage("Invalid Year: Year must have 4 digits")
            .Must(ValidationMethods.BeOnlyNumeric).WithMessage("Invalid Year: only digits are permited");
        RuleFor(v => v.OwnerId)
            .NotEmpty().WithMessage("Invalid Year: field cannot be empty");
    }
}