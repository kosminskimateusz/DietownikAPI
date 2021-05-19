using Dietownik.ApplicationServices.API.Domain.Recipes;
using FluentValidation;

namespace Dietownik.ApplicationServices.API.Validators
{
    public class UpdateRecipeRequestValidator : AbstractValidator<AddRecipeRequest>
    {
        public UpdateRecipeRequestValidator()
        {
            this.RuleFor(x => x.Name).MaximumLength(250);
        }
    }
}