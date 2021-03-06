﻿using FluentValidation;

namespace UIT.iDeal.Commands.AddUser
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(x => x.Firstname).NotNull().Length(2, 50);
            RuleFor(x => x.Lastname).NotNull().Length(2, 50);
            RuleFor(x => x.Username).NotNull().Length(3, 50);
            RuleFor(x => x.Email).NotNull().Length(3, 50);
            RuleFor(x => x.ApplicationRoleIds).NotEmpty().WithMessage("Please select at least one application role");
            RuleFor(x => x.BusinessUnitIds).NotEmpty().WithMessage("Please select at least one business unit");
        }
    }
}
