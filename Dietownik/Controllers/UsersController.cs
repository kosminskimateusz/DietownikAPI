using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dietownik.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UsersController : ApiControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<UsersController> logger;

        public UsersController(IMediator mediator, ILogger<UsersController> logger) : base(mediator, logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            if (request.SearchUsername == null)
                this.logger.LogInformation("Get Users");
            else
                this.logger.LogInformation($"Get Users contains /'{request.SearchUsername}/' in name");

            return await this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }
        // POST api/users
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            logger.LogInformation($"Add User: {request.Username}");

            return await this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }
    }
}