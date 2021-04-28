using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.SavedRecipes
{
    public class DeleteSavedRecipeCommand : CommandBase<SavedRecipe, SavedRecipe>
    {
        public async override Task<SavedRecipe> Execute(RecipeStorageContext context)
        {
            context.SavedRecipes.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}