using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Recipes
{
    public class UpdateRecipeCommand : CommandBase<Recipe, Recipe>
    {
        public async override Task<Recipe> Execute(RecipeStorageContext context)
        {
            context.Recipes.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}