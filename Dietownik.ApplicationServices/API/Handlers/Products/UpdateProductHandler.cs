using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Products;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.Products;
using Dietownik.DataAccess.CQRS.Queries.Products;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public UpdateProductHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            // var query = new GetProductByIdQuery()
            // {
            //     Id = request.ProductId
            // };
            // var product = await this.queryExecutor.Execute(query);
            var updatedProduct = this.mapper.Map<DataAccess.Entities.Product>(request);
            var command = new UpdateProductCommand()
            {
                Parameter = updatedProduct
            };
            var updateDb = await this.commandExecutor.Execute(command);
            var response = new UpdateProductResponse()
            {
                Data = this.mapper.Map<ApplicationServices.API.Domain.Models.Product>(updatedProduct)
            };
            return response;
        }
    }
}