using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Ingredients;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.Ingredients;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Ingredients
{
    public class AddIngredientHandler : IRequestHandler<AddIngredientRequest, AddIngredientResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddIngredientHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddIngredientResponse> Handle(AddIngredientRequest request, CancellationToken cancellationToken)
        {
            var ingredient = this.mapper.Map<EntityIngredient>(request);
            var command = new AddIngredientCommand()
            {
                Parameter = ingredient
            };
            var ingredientFromDb = await this.commandExecutor.Execute(command);
            return new AddIngredientResponse()
            {
                Data = this.mapper.Map<ApplicationServices.API.Domain.Models.ModelIngredient>(ingredientFromDb)
            };
        }
    }
}