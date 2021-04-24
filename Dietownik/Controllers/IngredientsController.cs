using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Ingredients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ApiControllerBase
    {
        public IngredientsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddRecipeIngredient([FromBody] AddIngredientRequest request)
        {
            return await this.HandleRequest<AddIngredientRequest, AddIngredientResponse>(request);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllIngredients([FromQuery] GetIngredientsRequest request)
        {
            return await this.HandleRequest<GetIngredientsRequest, GetIngredientsResponse>(request);
        }
    }
}