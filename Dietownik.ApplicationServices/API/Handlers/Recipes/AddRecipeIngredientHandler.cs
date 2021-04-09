using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Recipes;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Recipes
{
    public class AddRecipeIngredientHandler : IRequestHandler<AddRecipeIngredientRequest, AddRecipeIngredientResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddRecipeIngredientHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddRecipeIngredientResponse> Handle(AddRecipeIngredientRequest request, CancellationToken cancellationToken)
        {
            var ingredient = this.mapper.Map<Ingredient>(request);
            var command = new AddRecipeIngredientCommand()
            {
                Parameter = ingredient
            };
            var ingredientFromDb = await commandExecutor.Execute(command);
            return new AddRecipeIngredientResponse()
            {
                Data = mapper.Map<ApplicationServices.API.Domain.Models.Ingredient>(ingredientFromDb)
            };
        }
    }
}