using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.SavedRecipes;
using Dietownik.ApplicationServices.API.ErrorHandling;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.SavedRecipes;
using Dietownik.DataAccess.CQRS.Queries.SavedRecipes;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.SavedRecipes
{
    public class DeleteSavedRecipeHandler : IRequestHandler<DeleteSavedRecipeRequest, DeleteSavedRecipeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteSavedRecipeHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteSavedRecipeResponse> Handle(DeleteSavedRecipeRequest request, CancellationToken cancellationToken)
        {
            var savedRecipe = this.mapper.Map<EntitySavedRecipe>(request);

            var query = new GetSavedRecipeByIdQuery() { Id = request.SavedRecipeId };
            var productGetById = await queryExecutor.Execute(query);
            if (productGetById == null)
            {
                return new DeleteSavedRecipeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteSavedRecipeCommand()
            {
                Parameter = savedRecipe
            };
            var savedRecipeFromDb = await this.commandExecutor.Execute(command);
            return new DeleteSavedRecipeResponse()
            {
                Data = this.mapper.Map<ModelSavedRecipe>(savedRecipeFromDb)
            };
        }
    }
}