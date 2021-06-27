using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Dietownik.ApplicationServices.API.Domain.Users;
using FluentValidation;

namespace Dietownik.ApplicationServices.API.Validators
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        string regexItem = @"[\[\{\}\`\~\!\@\#\$\%\^\&\*\-\=\+\,\.\/\<\>\?\]]";
        char splitChar = '\\';
        public AddUserRequestValidator()
        {
            var regexString = RegexToString();
            this.RuleFor(x => x.Username).NotEmpty()
                .MinimumLength(6)
                .MaximumLength(50)
                .Must(x => !x.Contains(' ')).WithMessage("Your username can not contains white spaces.")
                .NotEqual(x => x.Password).WithMessage("'Username' can not be equal to 'Password'");
            this.RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(50).WithMessage("Your password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Must(x => !x.Contains(' ')).WithMessage("Your password can not contains white spaces.")
                .Matches(regexItem).WithMessage($"Your password must contain at least one of chars: {regexString}");
            this.RuleFor(x => x.Email).NotEmpty()
                .EmailAddress()
                .MaximumLength(50)
                .Must(x => !x.Contains(' ')).WithMessage("Your e-mail can not contains white spaces.");
        }

        private string RegexToString()
        {
            var regexToPrint = regexItem.Split(splitChar);
            StringBuilder regex = new StringBuilder();

            foreach (var reg in regexToPrint)
            {
                if (!regex.ToString().Contains(reg))
                {
                    if (reg == "]]")
                        regex.Append("]");
                    else
                    {
                        regex.Append(reg);
                        regex.Append(" ");
                    }
                }
            }
            return regex.ToString();
        }
    }
}