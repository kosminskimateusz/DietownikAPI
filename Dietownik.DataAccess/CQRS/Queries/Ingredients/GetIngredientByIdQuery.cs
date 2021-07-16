using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Ingredients
{
    public class GetIngredientByIdQuery : QueryBase<EntityIngredient>
    {
        public int Id { get; set; }
        public async override Task<EntityIngredient> Execute(RecipeStorageContext context)
        {
            var ingredient = await context.Ingredients.FirstOrDefaultAsync(ingredient => ingredient.Id == this.Id);
            // Added EntityState.Detached for check in Delete Handler that entity exists and if yes than execute Delete command
            if (ingredient != null)
                context.Entry(ingredient).State = EntityState.Detached;
            return ingredient;
        }
    }
}