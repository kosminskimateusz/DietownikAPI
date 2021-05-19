
using Dietownik.ApplicationServices.API.Domain.SavedRecipes;
using FluentValidation;

namespace Dietownik.ApplicationServices.API.Validators
{
    public class UpdateSavedRecipeRequestValidator : AbstractValidator<UpdateSavedRecipeRequest>
    {
        public UpdateSavedRecipeRequestValidator()
        {
            this.RuleFor(x => x.PreferedKcal).GreaterThanOrEqualTo(50);
        }
    }
}