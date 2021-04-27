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
    }
}