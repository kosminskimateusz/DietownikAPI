using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ApiControllerBase
    {
        protected IngredientsController(IMediator mediator) : base(mediator)
        {
        }
    }
}