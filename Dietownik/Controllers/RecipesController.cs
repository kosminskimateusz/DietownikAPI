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
    public class RecipesController : ControllerBase
    {
        private readonly IMediator mediator;

        public RecipesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllRecipes([FromQuery] GetRecipesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}