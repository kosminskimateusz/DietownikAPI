using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.Products;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.Products;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Products
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddProductHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var product = this.mapper.Map<EntityProduct>(request);
            var command = new AddProductCommand() { Parameter = product };
            var productFromDb = await this.commandExecutor.Execute(command);

            return new AddProductResponse()
            {
                Data = this.mapper.Map<ModelProduct>(productFromDb)
            };
        }
    }
}