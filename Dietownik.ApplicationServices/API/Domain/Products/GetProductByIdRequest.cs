using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Products
{
    public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
    {
        public int ProductId { get; set; }
    }
}