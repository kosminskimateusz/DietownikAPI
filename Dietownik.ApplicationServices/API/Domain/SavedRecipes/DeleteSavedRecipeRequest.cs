using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.SavedRecipes
{
    public class DeleteSavedRecipeRequest : IRequest<DeleteSavedRecipeResponse>
    {
        public int SavedRecipeId { get; set; }
    }
}