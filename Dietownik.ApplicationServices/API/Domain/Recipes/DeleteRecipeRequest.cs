using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Recipes
{
    public class DeleteRecipeRequest : IRequest<DeleteRecipeResponse>
    {
        public int RecipeId { get; set; }
    }
}