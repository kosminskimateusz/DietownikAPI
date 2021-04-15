using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Products
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public int productId;
        public string Name { get; set; }
        public decimal Kcal { get; set; }
        public decimal Fats { get; set; }
        public decimal Carbs { get; set; }
        public decimal Proteins { get; set; }
    }
}