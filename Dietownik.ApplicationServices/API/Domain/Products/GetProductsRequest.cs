using MediatR;

namespace Dietownik.ApplicationServices.API.Domain
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public string ContainsInName { get; set; }
    }
}