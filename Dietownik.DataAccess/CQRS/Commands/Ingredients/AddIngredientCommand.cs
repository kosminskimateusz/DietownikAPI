using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Ingredients
{
    public class AddIngredientCommand : CommandBase<EntityIngredient, EntityIngredient>
    {
        public override async System.Threading.Tasks.Task<EntityIngredient> Execute(RecipeStorageContext context)
        {
            await context.Ingredients.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}