using FluentValidation;

namespace Domain.Validators;

public class UpdateVehicleModelValidator : VehicleModelValidator
{
    public UpdateVehicleModelValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Invalid ID: field cannot be empty");
    }
}