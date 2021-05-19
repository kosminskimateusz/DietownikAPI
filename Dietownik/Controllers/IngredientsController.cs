using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Ingredients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("api/ingredients")]
    public class IngredientsController : ApiControllerBase
    {
        public IngredientsController(IMediator mediator) : base(mediator)
        {
        }

        // GET api/ingredients
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetIngredients([FromQuery] GetIngredientsRequest request)
        {
            return await this.HandleRequest<GetIngredientsRequest, GetIngredientsResponse>(request);
        }

        // POST api/ingredients
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddIngredient([FromBody] AddIngredientRequest request)
        {
            return await this.HandleRequest<AddIngredientRequest, AddIngredientResponse>(request);
        }

        // PUT api/ingredients/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateIngredient([FromRoute] int id, [FromBody] UpdateIngredientRequest request)
        {
            request.ingredientId = id;
            return await this.HandleRequest<UpdateIngredientRequest, UpdateIngredientResponse>(request);
        }

        // DELETE api/ingredients/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteIngredient([FromRoute] int id)
        {
            var request = new DeleteIngredientRequest()
            {
                IngredientId = id
            };
            return await this.HandleRequestWithoutResponseBody<DeleteIngredientRequest, DeleteIngredientResponse>(request);
        }
    }
}