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
    public class DeleteIngredientHandler : IRequestHandler<DeleteIngredientRequest, DeleteIngredientResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteIngredientHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteIngredientResponse> Handle(DeleteIngredientRequest request, CancellationToken cancellationToken)
        {
            var ingredient = this.mapper.Map<EntityIngredient>(request);
            var command = new DeleteIngredientCommand()
            {
                Parameter = ingredient
            };
            var ingredientFromDb = await this.commandExecutor.Execute(command);
            return new DeleteIngredientResponse()
            {
                Data = this.mapper.Map<Domain.Models.ModelIngredient>(ingredientFromDb)
            };
        }
    }
}