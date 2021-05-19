using Dietownik.ApplicationServices.API.Domain.Ingredients;
using FluentValidation;

namespace Dietownik.ApplicationServices.API.Validators
{
    public class UpdateIngredientRequestValidator : AbstractValidator<UpdateIngredientRequest>
    {
        public UpdateIngredientRequestValidator()
        {
            this.RuleFor(x => x.Weigth).GreaterThan(0);
            this.RuleFor(x => x.ProductId).GreaterThanOrEqualTo(1);
            this.RuleFor(x => x.RecipeId).GreaterThanOrEqualTo(1);
        }
    }
}