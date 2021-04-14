using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Recipes;
using Dietownik.ApplicationServices.Mappings;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS.Queries.Products;
using Dietownik.DataAccess.CQRS.Queries.Recipes;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Recipes
{
    public class GetRecipesHandler : IRequestHandler<GetRecipesRequest, GetRecipesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly IFullRecipeMap recipeMap;

        public GetRecipesHandler(IMapper mapper, IQueryExecutor queryExecutor, IFullRecipeMap recipeMap)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.recipeMap = recipeMap;
        }
        public async Task<GetRecipesResponse> Handle(GetRecipesRequest request, CancellationToken cancellationToken)
        {
            var recipesQuery = new GetRecipesQuery()
            {
                SearchPhrase = request.SearchPhrase
            };
            var recipes = await queryExecutor.Execute(recipesQuery);

            // Wyciągnięcie modelu Recipe do wyświetlenia przy pomocy foreach

            List<ApplicationServices.API.Domain.Models.Recipe> recipesModel = new List<Domain.Models.Recipe>();

            foreach (var recipe in recipes)
            {
                var mappedRecipe = await recipeMap.Map(recipe);
                recipesModel.Add(mappedRecipe);
            }

            // Koniec

            var response = new GetRecipesResponse()
            {
                Data = recipesModel
            };

            return response;
        }
    }
}