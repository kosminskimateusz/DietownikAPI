using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Recipes
{
    public class DeleteRecipeCommand : CommandBase<EntityRecipe, EntityRecipe>
    {
        public async override Task<EntityRecipe> Execute(RecipeStorageContext context)
        {
            context.Recipes.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}