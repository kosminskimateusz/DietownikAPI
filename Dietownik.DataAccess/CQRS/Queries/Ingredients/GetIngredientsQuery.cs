using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Ingredients
{
    public class GetIngredientsQuery : QueryBase<List<EntityIngredient>>
    {
        public int RecipeIdSearch { get; set; }
        public override Task<List<EntityIngredient>> Execute(RecipeStorageContext context)
        {
            if (this.RecipeIdSearch == 0)
            {
                return context.Ingredients
                .ToListAsync();
            }
            return context.Ingredients
            .Where(ingredient => ingredient.EntityRecipeId.Equals(this.RecipeIdSearch))
            .ToListAsync();
        }
    }
}
