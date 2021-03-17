using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain;
using Dietownik.DataAccess;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IRepository<Product> productRepository;

        public GetProductsHandler(IRepository<Dietownik.DataAccess.Entities.Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        public Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = this.productRepository.GetAll();
            var domainProducts = products.Select(product => new Domain.Models.Product()
            {
                Id = product.Id,
                Name = product.Name
            });

            var response = new GetProductsResponse()
            {
                Data = domainProducts.ToList()
            };
            return Task.FromResult(response);
        }
    }
}