using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Recipes
{
    public class AddRecipeRequest : IRequest<AddRecipeResponse>
    {
        public string Name { get; set; }
    }
}