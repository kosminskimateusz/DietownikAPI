using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Ingredients
{
    public class GetIngredientsQuery : QueryBase<List<Ingredient>>
    {
        public int RecipeIdSearch { get; set; }
        public override Task<List<Ingredient>> Execute(RecipeStorageContext context)
        {
            if (this.RecipeIdSearch == 0)
            {
                return context.Ingredients
                .ToListAsync();
            }
            return context.Ingredients
            .Where(ingredient => ingredient.RecipeId.Equals(this.RecipeIdSearch))
            .ToListAsync();
        }
    }
}
