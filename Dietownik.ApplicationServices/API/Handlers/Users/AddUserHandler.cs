using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.Users;
using Dietownik.ApplicationServices.API.ErrorHandling;
using Dietownik.ApplicationServices.Components;
using Dietownik.DataAccess;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Commands.Users;
using Dietownik.DataAccess.CQRS.Queries.Users;
using Dietownik.DataAccess.Entities;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Users
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHasher passwordHasher;

        public AddUserHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IPasswordHasher passwordHasher)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.passwordHasher = passwordHasher;
        }
        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            bool usernameExist = await UsernameExistCheck(request.Username);
            bool emailExist = await EmailExistCheck(request.Email);

            if (usernameExist)
                return new AddUserResponse()
                {
                    Error = new Domain.ErrorModel("This username is already used.")
                };

            if (emailExist)
                return new AddUserResponse()
                {
                    Error = new Domain.ErrorModel("This e-mail adress is already used.")
                };
            request.Password = passwordHasher.Hash(request.Password);
            var user = this.mapper.Map<EntityUser>(request);
            var command = new AddUserCommand()
            {
                Parameter = user
            };
            var userFromDb = await this.commandExecutor.Execute(command);

            return new AddUserResponse()
            {
                Data = this.mapper.Map<ModelUser>(userFromDb)
            };
        }

        private async Task<bool> EmailExistCheck(string email)
        {
            var query = new GetUsersQuery();
            var users = await queryExecutor.Execute(query);
            var existingUser = users.Where(x => x.Email == email).FirstOrDefault();

            // return (existingUser != null) ? true : false;
            return (existingUser != null);
        }

        private async Task<bool> UsernameExistCheck(string username)
        {
            var query = new GetUsersQuery();
            var users = await queryExecutor.Execute(query);
            var existingUser = users.Where(x => x.Username == username).FirstOrDefault();

            // return (existingUser != null) ? true : false;
            return (existingUser != null);
        }
    }
}