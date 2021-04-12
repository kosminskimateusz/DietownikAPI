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
    public class UpdateRecipeHandler : IRequestHandler<UpdateRecipeRequest, UpdateRecipeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public UpdateRecipeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<UpdateRecipeResponse> Handle(UpdateRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipe = this.mapper.Map<Recipe>(request);
            var command = new UpdateRecipeCommand()
            {
                Parameter = recipe
            };
            var updatedRecipe = await commandExecutor.Execute(command);
            return new UpdateRecipeResponse()
            {
                Data = mapper.Map<ApplicationServices.API.Domain.Models.Recipe>(updatedRecipe)
            };
        }
    }
}