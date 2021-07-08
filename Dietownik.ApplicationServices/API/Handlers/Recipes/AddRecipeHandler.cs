using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.Recipes;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.Recipes;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Recipes
{
    public class AddRecipeHandler : IRequestHandler<AddRecipeRequest, AddRecipeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddRecipeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddRecipeResponse> Handle(AddRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipe = this.mapper.Map<EntityRecipe>(request);
            var command = new AddRecipeCommand() { Parameter = recipe };
            var productFromDb = await this.commandExecutor.Execute(command);

            return new AddRecipeResponse()
            {
                Data = this.mapper.Map<ModelRecipe>(productFromDb)
            };
        }
    }
}