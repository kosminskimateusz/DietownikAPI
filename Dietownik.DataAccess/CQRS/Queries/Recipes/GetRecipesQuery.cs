using System.Collections.Generic;
using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Recipes
{
    public class GetRecipesQuery : QueryBase<List<Recipe>>
    {
        public override Task<List<Recipe>> Execute(RecipeStorageContext context)
        {
            return context.Recipes
            .Include(x => x.Ingredients)
            .ToListAsync();
        }
    }
}