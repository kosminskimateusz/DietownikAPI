using System.Collections.Generic;
using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain;
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
    }
}