using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.Recipes;
using Dietownik.ApplicationServices.API.ErrorHandling;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Queries.Recipes;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Recipes
{
    public class GetRecipeByIdHandler : IRequestHandler<GetRecipeByIdRequest, GetRecipeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetRecipeByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetRecipeByIdResponse> Handle(GetRecipeByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetRecipeByIdQuery()
            {
                Id = request.RecipeId
            };

            var recipe = await this.queryExecutor.Execute(query);

            if (recipe == null)
            {
                return new GetRecipeByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }
            return new GetRecipeByIdResponse()
            {
                Data = this.mapper.Map<ModelRecipe>(recipe)
            };
        }
    }
}