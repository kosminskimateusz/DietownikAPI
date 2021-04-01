using MediatR;

namespace Dietownik.ApplicationServices.API.Domain
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {
        public int ProductId { get; set; }
    }
}