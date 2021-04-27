using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Users;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.Users;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Users
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddUserHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);
            var command = new AddUserCommand()
            {
                Parameter = user
            };
            var userFromDb = await this.commandExecutor.Execute(command);

            return new AddUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(userFromDb)
            };
        }
    }
}