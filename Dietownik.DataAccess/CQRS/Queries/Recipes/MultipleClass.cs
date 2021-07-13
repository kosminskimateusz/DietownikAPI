using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Queries.Recipes
{
    public class MultipleClass
    {
        public EntityProduct products { get; set; }
        public EntityIngredient ingredients { get; set; }
        public EntityRecipe recipes { get; set; }
    }
}