using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Ingredients
{
    public class DeleteIngredientCommand : CommandBase<Ingredient, Ingredient>
    {
        public override async Task<Ingredient> Execute(RecipeStorageContext context)
        {
            context.Ingredients.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}