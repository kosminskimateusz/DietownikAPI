using System.Collections.Generic;
using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Recipes;
using Dietownik.DataAccess;
using Dietownik.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipesController : ApiControllerBase
    {
        private readonly ILogger<RecipesController> logger;

        public RecipesController(IMediator mediator, ILogger<RecipesController> logger) : base(mediator, logger)
        {
            this.logger = logger;
        }

        // GET api/recipes
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetRecipes([FromQuery] GetRecipesRequest request)
        {
            if (request.SearchPhrase == null)
                this.logger.LogInformation("Get Recipes");
            else
                this.logger.LogInformation($"Get Recipes contains {request.SearchPhrase} in name");
            return await this.HandleRequest<GetRecipesRequest, GetRecipesResponse>(request);
        }

        // GET api/recipes/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRecipeById([FromRoute] int id)
        {
            this.logger.LogInformation($"Get Recipe with id: {id}");
            var request = new GetRecipeByIdRequest()
            {
                RecipeId = id
            };
            return await this.HandleRequest<GetRecipeByIdRequest, GetRecipeByIdResponse>(request);
        }

        // POST api/recipes
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddRecipe([FromBody] AddRecipeRequest request)
        {
            this.logger.LogInformation($"Add Recipe {request.Name}");
            return await this.HandleRequest<AddRecipeRequest, AddRecipeResponse>(request);
        }

        // PUT api/recipes/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRecipe([FromRoute] int id, [FromBody] UpdateRecipeRequest request)
        {
            this.logger.LogInformation($"Update Recipe with id: {id}");
            request.recipeId = id;
            return await this.HandleRequest<UpdateRecipeRequest, UpdateRecipeResponse>(request);
        }

        // DELETE api/recipes/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRecipe([FromRoute] int id)
        {
            logger.LogInformation($"Delete Recipe with id: {id}");
            var request = new DeleteRecipeRequest()
            {
                RecipeId = id
            };
            return await this.HandleRequestWithoutResponseBody<DeleteRecipeRequest, DeleteRecipeResponse>(request);
        }
    }
}