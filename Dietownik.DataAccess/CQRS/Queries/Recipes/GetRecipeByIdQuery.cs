using System.Linq;
using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Recipes
{
    public class GetRecipeByIdQuery : QueryBase<Recipe>
    {
        public int Id { get; set; }
        public async override Task<Recipe> Execute(RecipeStorageContext context)
        {
            var recipe = await context.Recipes.FirstOrDefaultAsync(recipe => recipe.Id == this.Id);
            return recipe;
        }
    }
}