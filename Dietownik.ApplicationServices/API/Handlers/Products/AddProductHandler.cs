using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands;
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
            var product = this.mapper.Map<Product>(request);
            var command = new AddProductCommand() { Parameter = product };
            var productFromDb = await this.commandExecutor.Execute(command);
            return new AddProductResponse()
            {
                Data = this.mapper.Map<Dietownik.ApplicationServices.API.Domain.Models.Product>(productFromDb)
            };
        }
    }
}