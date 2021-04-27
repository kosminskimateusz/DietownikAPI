using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.SavedRecipes
{
    public class GetSavedRecipesQuery : QueryBase<List<SavedRecipe>>
    {
        public override Task<List<SavedRecipe>> Execute(RecipeStorageContext context)
        {
            return context.SavedRecipes.ToListAsync();
        }
    }
}