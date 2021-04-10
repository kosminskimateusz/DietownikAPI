using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Recipes;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands;
using Dietownik.DataAccess.CQRS.Queries;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Recipes
{
    public class AddRecipeIngredientHandler : IRequestHandler<AddRecipeIngredientRequest, AddRecipeIngredientResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public AddRecipeIngredientHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddRecipeIngredientResponse> Handle(AddRecipeIngredientRequest request, CancellationToken cancellationToken)
        {
            var ingredient = this.mapper.Map<Ingredient>(request);

            var command = new AddRecipeIngredientCommand()
            {
                Parameter = ingredient
            };
            var ingredientFromDb = await commandExecutor.Execute(command);

            var query = new GetProductByIdQuery()
            {
                Id = request.ProductId
            };
            var productForIngredient = await this.queryExecutor.Execute(query);
            var fullIngredient = new ApplicationServices.API.Domain.Models.Ingredient()
            {
                Id = ingredientFromDb.Id,
                Weigth = ingredientFromDb.Weigth,
                Name = productForIngredient.Name,
                Kcal = productForIngredient.Kcal * ingredientFromDb.Weigth / 100
            };
            return new AddRecipeIngredientResponse()
            {
                Data = fullIngredient
            };
        }
    }
}