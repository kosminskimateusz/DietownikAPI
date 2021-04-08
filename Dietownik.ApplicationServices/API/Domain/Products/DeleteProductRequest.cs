using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Products
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {
        public int ProductId { get; set; }
    }
}