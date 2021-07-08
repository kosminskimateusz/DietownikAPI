using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.Products;
using Dietownik.ApplicationServices.API.ErrorHandling;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.Products;
using Dietownik.DataAccess.CQRS.Queries.Products;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateProductHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var updatedProduct = this.mapper.Map<EntityProduct>(request);

            var query = new GetProductByIdQuery() { Id = request.productId };
            var productGetById = await queryExecutor.Execute(query);
            if (productGetById == null)
            {
                return new UpdateProductResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new UpdateProductCommand()
            {
                Parameter = updatedProduct
            };
            var updateDb = await this.commandExecutor.Execute(command);

            return new UpdateProductResponse()
            {
                Data = this.mapper.Map<ModelProduct>(updatedProduct)
            };
        }
    }
}