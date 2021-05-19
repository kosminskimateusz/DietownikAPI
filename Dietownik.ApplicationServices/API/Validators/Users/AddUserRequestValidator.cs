using Dietownik.ApplicationServices.API.Domain.Users;
using FluentValidation;

namespace Dietownik.ApplicationServices.API.Validators
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            this.RuleFor(x => x.Username).MaximumLength(50);
            this.RuleFor(x => x.Password).MaximumLength(50);
            this.RuleFor(x => x.Email).MaximumLength(50);
        }
    }
}