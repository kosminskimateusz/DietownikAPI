using System.Collections.Generic;
using System.Linq;
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


            // Trying with LINQ
            // var ingredientsProductId = recipe.Ingredients.Select(ing => ing.ProductId);
            // var productsEqualsIngredients = products.Where(prod => ingredientsProductId.Contains(prod.Id));
            // foreach (var ingredient in recipe.Ingredients)
            // {
            //     foreach (var product in productsEqualsIngredients)
            //     {
            //         var fullIngredientModel = new API.Domain.Models.Ingredient()
            //         {
            //             Id = ingredient.Id,
            //             Weigth = ingredient.Weigth,
            //             Name = product.Name,
            //             Kcal = product.Kcal * ingredient.Weigth / 100
            //         };
            //         ingredientsModel.Add(fullIngredientModel);
            //     }
            // }

            var productsEnum = products.Select(product => product);
            var ingredientsEnum = recipe.Ingredients.Select(ingredient => ingredient);

            foreach (var ingredient in ingredientsEnum)
            {
                foreach (var product in productsEnum)
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