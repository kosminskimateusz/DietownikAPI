using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS.Queries;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public UpdateProductHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery()
            {
                Id = request.ProductId
            };
            var product = await this.queryExecutor.Execute(query);
            var mappedProduct = this.mapper.Map<Domain.Models.Product>(product);
            var response = new GetProductByIdResponse()
            {
                Data = mappedProduct
            };
            return response;
        }
    }
}