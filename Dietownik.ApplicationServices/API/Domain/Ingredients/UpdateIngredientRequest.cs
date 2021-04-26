using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Ingredients
{
    public class UpdateIngredientRequest : IRequest<UpdateIngredientResponse>
    {
        public int ingredientId;
        public int RecipeId { get; set; }
        public decimal Weigth { get; set; }
        public int ProductId { get; set; }
    }
}