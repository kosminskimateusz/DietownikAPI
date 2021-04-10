using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Recipes;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS.Queries;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Recipes
{
    public class GetRecipesHandler : IRequestHandler<GetRecipesRequest, GetRecipesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetRecipesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetRecipesResponse> Handle(GetRecipesRequest request, CancellationToken cancellationToken)
        {
            var recipesQuery = new GetRecipesQuery();
            var recipes = await queryExecutor.Execute(recipesQuery);

            var productsQuery = new GetProductsQuery();
            var products = await queryExecutor.Execute(productsQuery);

            List<ApplicationServices.API.Domain.Models.Ingredient> ingredientsModel = new List<Domain.Models.Ingredient>();
            List<ApplicationServices.API.Domain.Models.Recipe> recipesModel = new List<Domain.Models.Recipe>();

            foreach (var recipe in recipes)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    foreach (var product in products)
                    {
                        if (ingredient.ProductId == product.Id)
                        {
                            var fullIngredientModel = new ApplicationServices.API.Domain.Models.Ingredient()
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
                var mappedRecipe = new ApplicationServices.API.Domain.Models.Recipe()
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Ingredients = ingredientsModel
                };
                recipesModel.Add(mappedRecipe);
            }

            var response = new GetRecipesResponse()
            {
                Data = recipesModel
            };

            return response;
        }
    }
}