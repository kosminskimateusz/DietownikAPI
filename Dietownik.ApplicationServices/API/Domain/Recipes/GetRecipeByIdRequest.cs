using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Recipes
{
    public class GetRecipeByIdRequest : IRequest<GetRecipeByIdResponse>
    {
        public int RecipeId { get; set; }
    }
}