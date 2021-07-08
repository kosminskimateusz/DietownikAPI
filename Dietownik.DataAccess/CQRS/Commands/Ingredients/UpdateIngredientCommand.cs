using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Ingredients
{
    public class UpdateIngredientCommand : CommandBase<EntityIngredient, EntityIngredient>
    {
        public override async Task<EntityIngredient> Execute(RecipeStorageContext context)
        {
            context.Ingredients.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}