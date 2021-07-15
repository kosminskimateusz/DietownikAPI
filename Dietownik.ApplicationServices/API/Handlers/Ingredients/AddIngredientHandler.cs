using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain;
using Dietownik.ApplicationServices.API.Domain.Ingredients;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.Ingredients;
using Dietownik.DataAccess.CQRS.Queries.Products;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Ingredients
{
    public class AddIngredientHandler : IRequestHandler<AddIngredientRequest, AddIngredientResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public AddIngredientHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public IQueryExecutor QueryExecutor { get; }

        public async Task<AddIngredientResponse> Handle(AddIngredientRequest request, CancellationToken cancellationToken)
        {
            bool productExist = await ProductExistCheck(request.ProductId);

            if (productExist)
            {
                var ingredient = this.mapper.Map<EntityIngredient>(request);
                var command = new AddIngredientCommand()
                {
                    Parameter = ingredient
                };
                var ingredientFromDb = await this.commandExecutor.Execute(command);
                return new AddIngredientResponse()
                {
                    Data = this.mapper.Map<ModelIngredient>(ingredientFromDb)
                };
            }
            else
                return new AddIngredientResponse()
                {
                    Error = new ErrorModel("Product not found.")
                };
        }

        private async Task<bool> ProductExistCheck(int productId)
        {
            var query = new GetProductsQuery();
            var products = await queryExecutor.Execute(query);
            var existingProducts = products.Where(x => x.Id == productId).FirstOrDefault();

            return (existingProducts != null) ? true : false;
        }
    }
}