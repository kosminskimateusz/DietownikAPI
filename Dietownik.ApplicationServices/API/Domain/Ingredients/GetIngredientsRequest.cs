using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Ingredients
{
    public class GetIngredientsRequest : IRequest<GetIngredientsResponse>
    {
        public int RecipeId { get; set; }
    }
}