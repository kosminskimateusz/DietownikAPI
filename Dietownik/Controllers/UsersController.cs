using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            return await this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }
    }
}