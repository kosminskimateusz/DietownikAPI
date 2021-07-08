using System;
using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.SavedRecipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("api/saved-recipes")]
    public class SavedRecipesController : ApiControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<SavedRecipesController> logger;

        public SavedRecipesController(IMediator mediator, ILogger<SavedRecipesController> logger) : base(mediator, logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        // GET api/saved-recipes
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetSavedRecipes([FromQuery] GetSavedRecipesRequest request)
        {
            if (request.UserId != 0 && request.Date == new DateTime())
                logger.LogInformation($"Get SavedRecipes user: {request.UserId}");
            else if (request.UserId != 0 && request.Date != new DateTime())
                logger.LogInformation($"Get SavedRecipes user: {request.UserId} from {request.Date}");
            else
                logger.LogInformation($"Get AllSavedRecipes");

            return await this.HandleRequest<GetSavedRecipesRequest, GetSavedRecipesResponse>(request);
        }

        // POST api/saved-recipes
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddSavedRecipe([FromBody] AddSavedRecipeRequest request)
        {
            if (this.ModelState.IsValid)
                logger.LogInformation($"Add SavedRecipe to user : {request.UserId}");

            return await this.HandleRequest<AddSavedRecipeRequest, AddSavedRecipeResponse>(request);
        }

        // PUT api/saved-recipes/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSavedRecipe([FromBody] UpdateSavedRecipeRequest request, [FromRoute] int id)
        {
            if (this.ModelState.IsValid)
                logger.LogInformation($"Update SavedRecipe id: {id}");

            request.id = id;
            return await this.HandleRequest<UpdateSavedRecipeRequest, UpdateSavedRecipeResponse>(request);
        }

        // DELETE api/saved-recipes/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSavedRecipe([FromRoute] int id)
        {
            if (this.ModelState.IsValid)
                logger.LogInformation($"Delete SavedRecipe id: {id}");

            var request = new DeleteSavedRecipeRequest()
            {
                SavedRecipeId = id
            };
            return await this.HandleRequestWithoutResponseBody<DeleteSavedRecipeRequest, DeleteSavedRecipeResponse>(request);
        }
    }
}