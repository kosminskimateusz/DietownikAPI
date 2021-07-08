using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.SavedRecipes
{
    public class DeleteSavedRecipeCommand : CommandBase<EntitySavedRecipe, EntitySavedRecipe>
    {
        public async override Task<EntitySavedRecipe> Execute(RecipeStorageContext context)
        {
            context.SavedRecipes.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}