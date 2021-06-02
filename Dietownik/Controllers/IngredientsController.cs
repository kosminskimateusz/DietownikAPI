using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Ingredients;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("api/ingredients")]
    public class IngredientsController : ApiControllerBase
    {
        private readonly ILogger<IngredientsController> logger;

        public IngredientsController(IMediator mediator, ILogger<IngredientsController> logger) : base(mediator, logger)
        {
            this.logger = logger;
        }

        // GET api/ingredients
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetIngredients([FromQuery] GetIngredientsRequest request)
        {
            this.logger.LogInformation("Get Ingredients");
            return await this.HandleRequest<GetIngredientsRequest, GetIngredientsResponse>(request);
        }

        // POST api/ingredients
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddIngredient([FromBody] AddIngredientRequest request)
        {
            this.logger.LogInformation($"Add Ingredient on ProductId: {request.ProductId} to RecipeId: {request.RecipeId}");
            return await this.HandleRequest<AddIngredientRequest, AddIngredientResponse>(request);
        }

        // PUT api/ingredients/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateIngredient([FromRoute] int id, [FromBody] UpdateIngredientRequest request)
        {
            this.logger.LogInformation($"Update Ingredient with id: {id}");
            request.ingredientId = id;
            return await this.HandleRequest<UpdateIngredientRequest, UpdateIngredientResponse>(request);
        }

        // DELETE api/ingredients/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteIngredient([FromRoute] int id)
        {
            logger.LogInformation($"Delete Ingredient with id: {id}");
            var request = new DeleteIngredientRequest()
            {
                IngredientId = id
            };
            return await this.HandleRequestWithoutResponseBody<DeleteIngredientRequest, DeleteIngredientResponse>(request);
        }
    }
}