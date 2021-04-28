using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.SavedRecipes;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.SavedRecipes;
using Dietownik.DataAccess.CQRS.Queries.SavedRecipes;
using Dietownik.DataAccess.Entities;
using MediatR;
using System.Linq;

namespace Dietownik.ApplicationServices.API.Handlers.SavedRecipes
{
    public class UpdateSavedRecipeHandler : IRequestHandler<UpdateSavedRecipeRequest, UpdateSavedRecipeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateSavedRecipeHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<UpdateSavedRecipeResponse> Handle(UpdateSavedRecipeRequest request, CancellationToken cancellationToken)
        {
            var savedRecipe = this.mapper.Map<SavedRecipe>(request);
            var command = new UpdateSavedRecipeCommand()
            {
                Parameter = savedRecipe
            };
            var savedRecipeFromDb = await this.commandExecutor.Execute(command);
            return new UpdateSavedRecipeResponse()
            {
                Data = this.mapper.Map<Domain.Models.SavedRecipe>(savedRecipeFromDb)
            };
        }
    }
}