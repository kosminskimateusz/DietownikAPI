using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Products;
using Dietownik.ApplicationServices.API.ErrorHandling;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.Products;
using Dietownik.DataAccess.CQRS.Queries.Products;
using Dietownik.DataAccess.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dietownik.ApplicationServices.API.Handlers.Products
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public DeleteProductHandler(ICommandExecutor commandExecutor,
        IQueryExecutor queryExecutor,
        IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = this.mapper.Map<EntityProduct>(request);
            var query = new GetProductByIdQuery() { Id = request.ProductId };
            var productGetById = await queryExecutor.Execute(query);
            if (productGetById == null)
            {
                return new DeleteProductResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }
            var command = new DeleteProductCommand() { Parameter = product };
            var productFromDb = await this.commandExecutor.Execute(command);

            return new DeleteProductResponse()
            {
                Data = this.mapper.Map<Dietownik.ApplicationServices.API.Domain.Models.ModelProduct>(productFromDb)
            };
        }
    }
}