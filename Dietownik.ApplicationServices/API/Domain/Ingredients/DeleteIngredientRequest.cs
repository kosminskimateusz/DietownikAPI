using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Ingredients
{
    public class DeleteIngredientRequest : IRequest<DeleteIngredientResponse>
    {
        public int IngredientId { get; set; }
    }
}