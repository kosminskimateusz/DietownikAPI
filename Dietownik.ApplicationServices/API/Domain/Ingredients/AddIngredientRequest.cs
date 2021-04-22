using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Ingredients
{
    public class AddIngredientRequest : IRequest<AddIngredientResponse>
    {
        public int RecipeId { get; set; }
        public decimal Weigth { get; set; }
        public int ProductId { get; set; }
    }
}