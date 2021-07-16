using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain;
using Dietownik.ApplicationServices.API.Domain.Ingredients;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.ErrorHandling;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.Ingredients;
using Dietownik.DataAccess.CQRS.Queries.Ingredients;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Ingredients
{
    public class DeleteIngredientHandler : IRequestHandler<DeleteIngredientRequest, DeleteIngredientResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteIngredientHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteIngredientResponse> Handle(DeleteIngredientRequest request, CancellationToken cancellationToken)
        {
            var ingredient = this.mapper.Map<EntityIngredient>(request);
            var query = new GetIngredientByIdQuery() { Id = request.IngredientId };
            var ingredientGetById = await queryExecutor.Execute(query);
            if (ingredientGetById == null)
            {
                return new DeleteIngredientResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteIngredientCommand()
            {
                Parameter = ingredient
            };
            var ingredientFromDb = await this.commandExecutor.Execute(command);
            return new DeleteIngredientResponse()
            {
                Data = this.mapper.Map<ModelIngredient>(ingredientFromDb)
            };
        }
    }
}