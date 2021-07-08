using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Recipes
{
    public class AddRecipeCommand : CommandBase<EntityRecipe, EntityRecipe>
    {
        public override async Task<EntityRecipe> Execute(RecipeStorageContext context)
        {
            await context.Recipes.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}