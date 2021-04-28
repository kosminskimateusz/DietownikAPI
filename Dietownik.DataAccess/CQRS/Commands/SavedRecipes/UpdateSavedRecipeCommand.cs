using System.Linq;
using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.SavedRecipes
{
    public class UpdateSavedRecipeCommand : CommandBase<SavedRecipe, SavedRecipe>
    {
        public async override Task<SavedRecipe> Execute(RecipeStorageContext context)
        {
            var result = context.SavedRecipes.SingleOrDefault(recipe => recipe.Id == this.Parameter.Id);
            result.PreferedKcal = this.Parameter.PreferedKcal;
            // context.SavedRecipes.Update(this.Parameter);
            await context.SaveChangesAsync();
            return result;
        }
    }
}