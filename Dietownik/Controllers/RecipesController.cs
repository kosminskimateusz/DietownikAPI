using System.Collections.Generic;
using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Recipes;
using Dietownik.DataAccess;
using Dietownik.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipesController : ApiControllerBase
    {
        public RecipesController(IMediator mediator) : base(mediator)
        {
        }

        // GET api/recipes
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetRecipes([FromQuery] GetRecipesRequest request)
        {
            return await this.HandleRequest<GetRecipesRequest, GetRecipesResponse>(request);
        }

        // GET api/recipes/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRecipeById([FromRoute] int id)
        {
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
            return await this.HandleRequest<AddRecipeRequest, AddRecipeResponse>(request);
        }

        // PUT api/recipes/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRecipe([FromRoute] int id, [FromBody] UpdateRecipeRequest request)
        {
            request.recipeId = id;
            return await this.HandleRequest<UpdateRecipeRequest, UpdateRecipeResponse>(request);
        }

        // DELETE api/recipes/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRecipe([FromRoute] int id)
        {
            var request = new DeleteRecipeRequest()
            {
                RecipeId = id
            };
            return await this.HandleRequestWithoutResponseBody<DeleteRecipeRequest, DeleteRecipeResponse>(request);
        }
    }
}