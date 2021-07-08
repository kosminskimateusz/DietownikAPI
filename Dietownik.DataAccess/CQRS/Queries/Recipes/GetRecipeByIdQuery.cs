using System.Linq;
using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Recipes
{
    public class GetRecipeByIdQuery : QueryBase<EntityRecipe>
    {
        public int Id { get; set; }
        public async override Task<EntityRecipe> Execute(RecipeStorageContext context)
        {
            var recipe = await context.Recipes.Include(x => x.Ingredients).FirstOrDefaultAsync(recipe => recipe.Id == this.Id);
            // Added EntityState.Detached for check in Delete Handler that entity exists and if yes than execute Delete command
            if (recipe != null)
                context.Entry(recipe).State = EntityState.Detached;
            return recipe;
        }
    }
}