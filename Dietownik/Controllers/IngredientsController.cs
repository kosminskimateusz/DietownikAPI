using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Ingredients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ApiControllerBase
    {
        public IngredientsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllIngredients([FromQuery] GetIngredientsRequest request)
        {
            return await this.HandleRequest<GetIngredientsRequest, GetIngredientsResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddIngredient([FromBody] AddIngredientRequest request)
        {
            return await this.HandleRequest<AddIngredientRequest, AddIngredientResponse>(request);
        }

        [HttpPut]
        [Route("{ingredientId}")]
        public async Task<IActionResult> UpdateIngredient([FromRoute] int ingredientId, [FromBody] UpdateIngredientRequest request)
        {
            request.ingredientId = ingredientId;
            return await this.HandleRequest<UpdateIngredientRequest, UpdateIngredientResponse>(request);
        }

        [HttpDelete]
        [Route("{ingredientId}")]
        public async Task<IActionResult> DeleteIngredient([FromRoute] int ingredientId)
        {
            var request = new DeleteIngredientRequest()
            {
                IngredientId = ingredientId
            };
            return await this.HandleRequestWithoutResponseBody<DeleteIngredientRequest, DeleteIngredientResponse>(request);
        }
    }
}