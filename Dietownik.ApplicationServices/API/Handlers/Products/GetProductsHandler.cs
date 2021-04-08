using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Products;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS.Queries;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Products
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductsQuery()
            {
                SearchPhrase = request.SearchPhrase
            };

            var products = await this.queryExecutor.Execute(query);
            var mappedProducts = this.mapper.Map<List<Domain.Models.Product>>(products);

            var response = new GetProductsResponse()
            {
                Data = mappedProducts
            };
            
            return response;
        }
    }
}