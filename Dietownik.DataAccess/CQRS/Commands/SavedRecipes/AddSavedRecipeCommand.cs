using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.SavedRecipes
{
    public class AddSavedRecipeCommand : CommandBase<EntitySavedRecipe, EntitySavedRecipe>
    {
        public async override Task<EntitySavedRecipe> Execute(RecipeStorageContext context)
        {
            await context.SavedRecipes.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}