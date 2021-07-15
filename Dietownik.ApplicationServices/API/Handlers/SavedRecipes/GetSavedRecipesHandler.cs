using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.SavedRecipes;
using Dietownik.ApplicationServices.API.ErrorHandling;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Queries.SavedRecipes;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.SavedRecipes
{
    public class GetSavedRecipesHandler : IRequestHandler<GetSavedRecipesRequest, GetSavedRecipesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetSavedRecipesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetSavedRecipesResponse> Handle(GetSavedRecipesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetSavedRecipesQuery()
            {
                UserId = request.UserId,
                Date = request.Date
            };
            var savedRecipes = await this.queryExecutor.Execute(query);

            if (savedRecipes == null)
            {
                return new GetSavedRecipesResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetSavedRecipesResponse()
            {
                Data = this.mapper.Map<List<ModelSavedRecipe>>(savedRecipes)
            };
        }
    }
}