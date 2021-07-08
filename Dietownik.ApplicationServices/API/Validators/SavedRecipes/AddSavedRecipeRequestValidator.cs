using Dietownik.ApplicationServices.API.Domain.SavedRecipes;
using FluentValidation;

namespace Dietownik.ApplicationServices.API.Validators
{
    public class AddSavedRecipeRequestValidator : AbstractValidator<AddSavedRecipeRequest>
    {
        public AddSavedRecipeRequestValidator()
        {
            this.RuleFor(x => x.PreferedKcal)
            .GreaterThanOrEqualTo(50);
            this.RuleFor(x => x.RecipeId).GreaterThanOrEqualTo(1);
            this.RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
        }
    }
}