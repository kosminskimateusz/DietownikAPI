using System.Collections.Generic;
using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS.Queries.Products;

namespace Dietownik.ApplicationServices.Mappings
{
    public class FullRecipeMap : IFullRecipeMap
    {
        private readonly IQueryExecutor queryExecutor;

        public FullRecipeMap(IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
        }

        public async Task<Recipe> Map(DataAccess.Entities.Recipe recipe)
        {
            var productsQuery = new GetProductsQuery();
            var products = await queryExecutor.Execute(productsQuery);

            List<API.Domain.Models.Ingredient> ingredientsModel = new List<API.Domain.Models.Ingredient>();

            foreach (var ingredient in recipe.Ingredients)
            {
                foreach (var product in products)
                {
                    if (ingredient.ProductId == product.Id)
                    {
                        var fullIngredientModel = new API.Domain.Models.Ingredient()
                        {
                            Id = ingredient.Id,
                            Weigth = ingredient.Weigth,
                            Name = product.Name,
                            Kcal = product.Kcal * ingredient.Weigth / 100
                        };
                        ingredientsModel.Add(fullIngredientModel);
                    }
                }
            }
            var mappedRecipe = new API.Domain.Models.Recipe()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Ingredients = ingredientsModel
            };
            return mappedRecipe;
        }
    }
}