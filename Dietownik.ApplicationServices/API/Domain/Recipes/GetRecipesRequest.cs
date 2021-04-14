using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Recipes
{
    public class GetRecipesRequest : IRequest<GetRecipesResponse>
    {
        public string SearchPhrase { get; set; }
    }
}