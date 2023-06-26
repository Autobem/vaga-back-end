using Domain.Models;
using Domain.Utils;
using FluentValidation;

namespace Domain.Validators;

public class OwnerModelValidator : AbstractValidator<OwnerModel>
{
    public OwnerModelValidator()
    {
        RuleFor(om => om.Name)
            .NotEmpty().WithMessage("Invalid Name: field cannot be empty");
        RuleFor(om => om.Cpf)
            .NotEmpty().WithMessage("Invalid CPF: field cannot be empty")
            .MinimumLength(11).WithMessage("Invalid CPF: must have at least 11 digits")
            .Must(ValidationMethods.BeOnlyNumeric).WithMessage("Invalid CPF: only digits are permited");
        RuleFor(om => om.Email)
            .NotEmpty().WithMessage("Invalid Email: field cannot be empty")
            .EmailAddress().WithMessage("Invalid Email: email format isn't valid");
        RuleFor(om => om.Phone)
            .NotEmpty().WithMessage("Invalid Phone: field cannot be empty")
            .Must(ValidationMethods.BeOnlyNumeric).WithMessage("Invalid Phone: only digits are permited");
        RuleFor(om => om.CNH)
            .NotEmpty().WithMessage("Invalid CNH: field cannot be empty")
            .MinimumLength(11).WithMessage("Invalid CNH: must have at least 11 digits")
            .Must(ValidationMethods.BeOnlyNumeric).WithMessage("Invalid CNH: only digits are permited");
        RuleFor(om => om.BirthDate)
            .NotEmpty().WithMessage("Invalid Birth Date: field cannot be empty");
    }
}