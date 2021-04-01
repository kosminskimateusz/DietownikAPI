using MediatR;

namespace Dietownik.ApplicationServices.API.Domain
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Kcal { get; set; }
        public decimal FatsPerHundredGramms { get; set; }
        public decimal CarbsPerHundredGrams { get; set; }
        public decimal ProteinsPerHundredGrams { get; set; }
    }
}