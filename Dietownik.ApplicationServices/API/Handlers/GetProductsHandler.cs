using System.Threading;
using System.Threading.Tasks;
// using Dietownik.ApplicationServices.API.Domain;
using Dietownik.DataAccess;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Product> productRepository;

        public GetProductsHandler(IRepository<Dietownik.DataAccess.Entities.Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        public Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}