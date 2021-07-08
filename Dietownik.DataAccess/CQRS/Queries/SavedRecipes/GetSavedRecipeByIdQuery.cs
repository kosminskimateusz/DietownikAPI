using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.SavedRecipes
{
    public class GetSavedRecipeByIdQuery : QueryBase<EntitySavedRecipe>
    {
        public int Id { get; set; }
        public override async Task<EntitySavedRecipe> Execute(RecipeStorageContext context)
        {
            var savedRecipe = await context.SavedRecipes.FirstOrDefaultAsync(savedRecipe => savedRecipe.Id == this.Id);
            // Added EntityState.Detached for check in Delete Handler that entity exists and if yes than execute Delete command
            if (savedRecipe != null)
                context.Entry(savedRecipe).State = EntityState.Detached;
            return savedRecipe;
        }
    }
}