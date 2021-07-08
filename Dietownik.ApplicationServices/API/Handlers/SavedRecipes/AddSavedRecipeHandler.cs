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
    public class AddSavedRecipeHandler : IRequestHandler<AddSavedRecipeRequest, AddSavedRecipeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddSavedRecipeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddSavedRecipeResponse> Handle(AddSavedRecipeRequest request, CancellationToken cancellationToken)
        {
            var savedRecipe = this.mapper.Map<EntitySavedRecipe>(request);
            var command = new AddSavedRecipeCommand()
            {
                Parameter = savedRecipe
            };
            var savedRecipeFromDb = await this.commandExecutor.Execute(command);

            return new AddSavedRecipeResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.ModelSavedRecipe>(savedRecipeFromDb)
            };
        }
    }
}