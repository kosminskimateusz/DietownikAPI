using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Recipes
{
    public class AddRecipeIngredientRequest : IRequest<AddRecipeIngredientResponse>
    {
        public decimal Weigth { get; set; }
        public int ProductId { get; set; }
        public int recipeId;
    }
}