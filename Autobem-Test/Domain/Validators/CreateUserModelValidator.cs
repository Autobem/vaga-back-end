using Domain.Models;
using FluentValidation;

namespace Domain.Validators;

public class CreateUserModelValidator : AbstractValidator<CreateUserModel>
{
	public CreateUserModelValidator()
	{
		RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Invalid Name: field cannot be empty");
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Invalid Email: field cannot be empty")
            .EmailAddress().WithMessage("Invalid Email: email format isn't valid");
        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Invalid Password: field cannot be empty")
            .Equal(u => u.PasswordConfirm).WithMessage("Invalid Password: Password and the Password Confirm don't match")
            .MinimumLength(8).WithMessage("Invalid Password: Your password length must be at least 8.")
            .Matches(@"[A-Z]+").WithMessage("Invalid Password: Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Invalid Password: Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Invalid Password: Your password must contain at least one number.");
        RuleFor(u => u.PasswordConfirm)
            .NotEmpty().WithMessage("Invalid Password Confirm: field cannot be empty");
    }
}