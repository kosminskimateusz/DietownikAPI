using Dietownik.ApplicationServices.API.Domain.Products;
using FluentValidation;

namespace Dietownik.ApplicationServices.API.Validators
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(2, 150);
            this.RuleFor(x => x.Kcal).InclusiveBetween(0, 900);
            this.RuleFor(x => x.Fats).InclusiveBetween(0, 100);
            this.RuleFor(x => x.Carbs).InclusiveBetween(0, 100);
            this.RuleFor(x => x.Proteins).InclusiveBetween(0, 100);
        }
    }
}