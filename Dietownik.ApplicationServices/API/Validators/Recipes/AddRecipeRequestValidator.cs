using Dietownik.ApplicationServices.API.Domain.Recipes;
using FluentValidation;

namespace Dietownik.ApplicationServices.API.Validators
{
    public class AddRecipeRequestValidator : AbstractValidator<AddRecipeRequest>
    {
        public AddRecipeRequestValidator()
        {
            this.RuleFor(x => x.Name).MaximumLength(250);
        }
    }
}