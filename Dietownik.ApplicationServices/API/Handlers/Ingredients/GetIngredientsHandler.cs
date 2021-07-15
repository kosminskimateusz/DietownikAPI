using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Ingredients;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.ErrorHandling;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Queries.Ingredients;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Ingredients
{
    public class GetIngredientsHandler : IRequestHandler<GetIngredientsRequest, GetIngredientsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetIngredientsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetIngredientsResponse> Handle(GetIngredientsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetIngredientsQuery()
            {
                RecipeIdSearch = request.RecipeId
            };

            var ingredients = await this.queryExecutor.Execute(query);

            if (ingredients == null)
            {
                return new GetIngredientsResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }
            return new GetIngredientsResponse()
            {
                Data = this.mapper.Map<List<ModelIngredient>>(ingredients)
            };
        }
    }
}