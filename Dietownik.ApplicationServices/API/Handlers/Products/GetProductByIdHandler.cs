using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Products;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS.Queries.Products;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Products
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetProductByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery()
            {
                Id = request.ProductId
            };

            var product = await this.queryExecutor.Execute(query);

            return new GetProductByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Product>(product)
            };
        }
    }
}