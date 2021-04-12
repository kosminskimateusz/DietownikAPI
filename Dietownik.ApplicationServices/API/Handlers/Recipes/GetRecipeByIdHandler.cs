using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.Recipes;
using Dietownik.ApplicationServices.Mappings;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS.Queries.Recipes;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Recipes
{
    public class GetRecipeByIdHandler : IRequestHandler<GetRecipeByIdRequest, GetRecipeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly IFullRecipeMap recipeMap;

        public GetRecipeByIdHandler(IMapper mapper, IQueryExecutor queryExecutor, IFullRecipeMap recipeMap)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.recipeMap = recipeMap;
        }
        public async Task<GetRecipeByIdResponse> Handle(GetRecipeByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetRecipeByIdQuery()
            {
                Id = request.RecipeId
            };
            var recipe = await this.queryExecutor.Execute(query);
            return new GetRecipeByIdResponse()
            {
                Data = await recipeMap.Map(recipe)
            };
        }
    }
}