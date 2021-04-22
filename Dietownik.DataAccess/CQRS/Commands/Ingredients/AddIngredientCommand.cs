using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Ingredients
{
    public class AddIngredientCommand : CommandBase<Ingredient, Ingredient>
    {
        public override async System.Threading.Tasks.Task<Ingredient> Execute(RecipeStorageContext context)
        {
            await context.Ingredients.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}