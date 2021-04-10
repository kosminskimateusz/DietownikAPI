using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Recipes;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.Recipes;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Recipes
{
    public class DeleteRecipeHandler : IRequestHandler<DeleteRecipeRequest, DeleteRecipeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteRecipeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteRecipeResponse> Handle(DeleteRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipe = this.mapper.Map<Recipe>(request);
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