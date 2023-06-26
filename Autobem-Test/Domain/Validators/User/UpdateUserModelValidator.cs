using Domain.Models.UserModels;
using FluentValidation;

namespace Domain.Validators.User;

public class UpdateUserModelValidator : AbstractValidator<UpdateUserModel>
{
    public UpdateUserModelValidator()
    {
        RuleFor(uu => uu.Id)
            .NotEmpty().WithMessage("Invalid ID: field cannot be empty");
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Invalid Name: field cannot be empty");
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Invalid Email: field cannot be empty")
            .EmailAddress().WithMessage("Invalid Email: email format isn't valid");
        RuleFor(uu => uu.Status)
            .IsInEnum().WithMessage("Invalid Status: Value given don't correspond to any existent Status values");
    }
}