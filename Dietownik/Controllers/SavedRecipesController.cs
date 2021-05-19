using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.SavedRecipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("api/saved-recipes")]
    public class SavedRecipesController : ApiControllerBase
    {
        public SavedRecipesController(IMediator mediator) : base(mediator)
        {
        }

        // GET api/saved-recipes
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetSavedRecipes([FromQuery] GetSavedRecipesRequest request)
        {
            return await this.HandleRequest<GetSavedRecipesRequest, GetSavedRecipesResponse>(request);
        }

        // POST api/saved-recipes
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddSavedRecipe([FromBody] AddSavedRecipeRequest request)
        {
            return await this.HandleRequest<AddSavedRecipeRequest, AddSavedRecipeResponse>(request);
        }

        // PUT api/saved-recipes/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSavedRecipe([FromBody] UpdateSavedRecipeRequest request, [FromRoute] int id)
        {
            request.id = id;
            return await this.HandleRequest<UpdateSavedRecipeRequest, UpdateSavedRecipeResponse>(request);
        }

        // DELETE api/saved-recipes/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSavedRecipe([FromRoute] int id)
        {
            var request = new DeleteSavedRecipeRequest()
            {
                SavedRecipeId = id
            };
            return await this.HandleRequestWithoutResponseBody<DeleteSavedRecipeRequest, DeleteSavedRecipeResponse>(request);
        }
    }
}