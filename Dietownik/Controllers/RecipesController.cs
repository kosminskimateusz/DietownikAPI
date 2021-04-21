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
    [Route("[controller]")]
    public class RecipesController : ApiControllerBase
    {
        public RecipesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllRecipes([FromQuery] GetRecipesRequest request)
        {
            return await this.HandleRequest<GetRecipesRequest, GetRecipesResponse>(request);
        }

        [HttpGet]
        [Route("{recipeId}")]
        public async Task<IActionResult> GetRecipeById([FromRoute] int recipeId)
        {
            var request = new GetRecipeByIdRequest()
            {
                RecipeId = recipeId
            };
            return await this.HandleRequest<GetRecipeByIdRequest, GetRecipeByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddRecipe([FromBody] AddRecipeRequest request)
        {
            return await this.HandleRequest<AddRecipeRequest, AddRecipeResponse>(request);
        }

        [HttpPost]
        [Route("{recipeId}/Ingredients")]
        public async Task<IActionResult> AddRecipeIngredient([FromRoute] int recipeId, [FromBody] AddRecipeIngredientRequest request)
        {
            request.recipeId = recipeId;
            return await this.HandleRequest<AddRecipeIngredientRequest, AddRecipeIngredientResponse>(request);
        }

        [HttpPut]
        [Route("{recipeId}")]
        public async Task<IActionResult> UpdateRecipe([FromRoute] int recipeId, [FromBody] UpdateRecipeRequest request)
        {
            request.recipeId = recipeId;
            return await this.HandleRequest<UpdateRecipeRequest, UpdateRecipeResponse>(request);
        }

        [HttpDelete]
        [Route("{recipeId}")]
        public async Task<IActionResult> DeleteRecipe([FromRoute] int recipeId)
        {
            var request = new DeleteRecipeRequest()
            {
                RecipeId = recipeId
            };
            return await this.HandleRequestWithoutResponseBody<DeleteRecipeRequest, DeleteRecipeResponse>(request);
        }
    }
}