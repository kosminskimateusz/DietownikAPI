using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Ingredients
{
    public class DeleteIngredientCommand : CommandBase<EntityIngredient, EntityIngredient>
    {
        public override async Task<EntityIngredient> Execute(RecipeStorageContext context)
        {
            context.Ingredients.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}