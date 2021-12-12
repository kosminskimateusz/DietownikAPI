using System.Security.Claims;
using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dietownik.Controllers
{

    [Authorize]
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


        [HttpGet]
        [Route("me")]
        public async Task<IActionResult> GetMe([FromQuery] GetMeRequest request)
        {
            request.id = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await this.HandleRequest<GetMeRequest, GetMeResponse>(request);
        }

        // POST api/users
        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            if (!this.ModelState.IsValid)
                this.logger.LogError($"Add User Failure");
            else
                this.logger.LogInformation($"Add User: {request.Username}");

            return await this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }
    }
}