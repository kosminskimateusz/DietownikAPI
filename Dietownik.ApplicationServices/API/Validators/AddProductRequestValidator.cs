using Dietownik.ApplicationServices.API.Domain;
using FluentValidation;

namespace Dietownik.ApplicationServices.API.Validators
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(2, 150);
            this.RuleFor(x => x.Kcal).GreaterThanOrEqualTo(0);
            this.RuleFor(x => x.FatsPerHundredGramms).InclusiveBetween(0,100);
            this.RuleFor(x => x.CarbsPerHundredGrams).InclusiveBetween(0,100);
            this.RuleFor(x => x.ProteinsPerHundredGrams).InclusiveBetween(0,100);
        }
    }
}