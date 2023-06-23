﻿using Domain.Models;
using Domain.Utils;
using FluentValidation;

namespace Domain.Validators
{
    public class UpdateOwnerModelValidator : OwnerModelValidator
    {
        public UpdateOwnerModelValidator()
        {
            RuleFor(om => om.Id)
                .NotEmpty().WithMessage("Invalid ID: field cannot be null");
        }
    }
}