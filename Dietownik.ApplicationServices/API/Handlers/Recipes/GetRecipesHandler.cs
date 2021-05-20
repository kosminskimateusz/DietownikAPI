using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.Recipes;
using Dietownik.ApplicationServices.API.ErrorHandling;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS.Queries.Recipes;
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
            var recipesQuery = new GetRecipesQuery()
            {
                SearchPhrase = request.SearchPhrase
            };

            var recipes = await queryExecutor.Execute(recipesQuery);

            if (recipes == null)
            {
                return new GetRecipesResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }
            return new GetRecipesResponse()
            {
                Data = this.mapper.Map<List<Recipe>>(recipes)
            };
        }
    }
}