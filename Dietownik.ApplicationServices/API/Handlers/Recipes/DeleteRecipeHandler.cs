using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Recipes;
using Dietownik.ApplicationServices.API.ErrorHandling;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.Recipes;
using Dietownik.DataAccess.CQRS.Queries.Recipes;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Recipes
{
    public class DeleteRecipeHandler : IRequestHandler<DeleteRecipeRequest, DeleteRecipeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteRecipeHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteRecipeResponse> Handle(DeleteRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipe = this.mapper.Map<Recipe>(request);
            var query = new GetRecipeByIdQuery() { Id = request.RecipeId };
            var productGetById = await queryExecutor.Execute(query);
            if (productGetById == null)
            {
                return new DeleteRecipeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteRecipeCommand()
            {
                Parameter = recipe
            };

            var deletedRecipe = await commandExecutor.Execute(command);

            return new DeleteRecipeResponse()
            {
                Data = this.mapper.Map<ApplicationServices.API.Domain.Models.Recipe>(deletedRecipe)
            };
        }
    }
}