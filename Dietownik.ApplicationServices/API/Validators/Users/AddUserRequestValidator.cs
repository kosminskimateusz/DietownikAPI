using System;
using System.Text.RegularExpressions;
using Dietownik.ApplicationServices.API.Domain.Users;
using FluentValidation;

namespace Dietownik.ApplicationServices.API.Validators
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        Regex regexItem = new Regex("!@#$%^");
        public AddUserRequestValidator()
        {
            this.RuleFor(x => x.Username).MaximumLength(50);
            this.RuleFor(x => x.Username != x.Password);
            this.RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(50).WithMessage("Your password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");
            this.RuleFor(x => x.Email).MaximumLength(50);
        }
    }
}