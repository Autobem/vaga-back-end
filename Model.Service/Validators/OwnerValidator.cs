using FluentValidation;
using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Service.Validators
{
    public class OwnerValidator : AbstractValidator<Owner>
    {
        public OwnerValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter the name.")
                .NotNull().WithMessage("Please enter the name.");

            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("Please enter the CPF.")
                .NotNull().WithMessage("Please enter the CPF.");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Please enter the last name.")
                .NotNull().WithMessage("Please enter the last name.");

            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("Please enter the phone number.")
                .NotNull().WithMessage("Please enter the phone number.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Please enter the email.")
                .NotNull().WithMessage("Please enter the email.");
        }
    }
}
