using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Recipes
{
    public class GetRecipesQuery : QueryBase<List<EntityRecipe>>
    {
        public string SearchPhrase { get; set; }
        public override Task<List<EntityRecipe>> Execute(RecipeStorageContext context)
        {

            if (this.SearchPhrase == null)
                return context.Recipes
                .Include(x => x.EntityIngredients)
                .ToListAsync();

            return context.Recipes
            .Where(recipe => recipe.Name.Contains(this.SearchPhrase))
            .Include(x => x.EntityIngredients)
            .ToListAsync();
        }
    }
}