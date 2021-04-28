using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.SavedRecipes;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.SavedRecipes;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.SavedRecipes
{
    public class DeleteSavedRecipeHandler : IRequestHandler<DeleteSavedRecipeRequest, DeleteSavedRecipeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteSavedRecipeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteSavedRecipeResponse> Handle(DeleteSavedRecipeRequest request, CancellationToken cancellationToken)
        {
            var savedRecipe = this.mapper.Map<SavedRecipe>(request);
            var command = new DeleteSavedRecipeCommand()
            {
                Parameter = savedRecipe
            };
            var savedRecipeFromDb = await this.commandExecutor.Execute(command);
            return new DeleteSavedRecipeResponse()
            {
                Data = this.mapper.Map<Domain.Models.SavedRecipe>(savedRecipeFromDb)
            };
        }
    }
}