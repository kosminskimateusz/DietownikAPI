using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.SavedRecipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SavedRecipesController : ApiControllerBase
    {
        public SavedRecipesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetSavedRecipes([FromQuery] GetSavedRecipesRequest request)
        {
            return await this.HandleRequest<GetSavedRecipesRequest, GetSavedRecipesResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddSavedRecipe([FromBody] AddSavedRecipeRequest request)
        {
            return await this.HandleRequest<AddSavedRecipeRequest, AddSavedRecipeResponse>(request);
        }

        [HttpPut]
        [Route("{savedRecipeId}")]
        public async Task<IActionResult> UpdateSavedRecipe([FromBody] UpdateSavedRecipeRequest request, [FromRoute] int savedRecipeId)
        {
            request.id = savedRecipeId;
            return await this.HandleRequest<UpdateSavedRecipeRequest, UpdateSavedRecipeResponse>(request);
        }

        [HttpDelete]
        [Route("{savedRecipeId}")]
        public async Task<IActionResult> DeleteSavedRecipe([FromRoute] int savedRecipeId)
        {
            var request = new DeleteSavedRecipeRequest()
            {
                SavedRecipeId = savedRecipeId
            };
            return await this.HandleRequestWithoutResponseBody<DeleteSavedRecipeRequest, DeleteSavedRecipeResponse>(request);
        }
    }
}