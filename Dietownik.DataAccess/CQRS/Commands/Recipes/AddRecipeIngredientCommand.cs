using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Recipes
{
    public class AddRecipeIngredientCommand : CommandBase<Ingredient, Ingredient>
    {
        public async override Task<Ingredient> Execute(RecipeStorageContext context)
        {
            await context.Ingredients.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}