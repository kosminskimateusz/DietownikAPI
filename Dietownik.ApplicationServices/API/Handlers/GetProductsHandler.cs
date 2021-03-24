using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain;
using Dietownik.DataAccess;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IRepository<Product> productRepository;
        private readonly IMapper mapper;

        public GetProductsHandler(IRepository<Dietownik.DataAccess.Entities.Product> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await this.productRepository.GetAll();
            var mappedProducts = this.mapper.Map<List<Domain.Models.Product>>(products);

            var response = new GetProductsResponse()
            {
                Data = mappedProducts
            };
            return response;
        }
    }
}