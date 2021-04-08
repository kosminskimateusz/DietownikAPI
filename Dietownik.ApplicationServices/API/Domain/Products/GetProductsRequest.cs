using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Products
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public string SearchPhrase { get; set; }
    }
}