using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dietownik.ApplicationServices.API.Domain.Models;
using Dietownik.ApplicationServices.API.Domain.Users;
using Dietownik.ApplicationServices.API.ErrorHandling;
using Dietownik.DataAccess.CQRS;
using Dietownik.DataAccess.CQRS.Queries.Users;
using MediatR;

namespace Dietownik.ApplicationServices.API.Handlers.Users
{
    public class GetUserHandler : IRequestHandler<GetMeRequest, GetMeResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUserHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetMeResponse> Handle(GetMeRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMeQuery
            {
                Id = request.id
            };

            var user = await this.queryExecutor.Execute(query);

            if (user == null)
            {
                return new GetMeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetMeResponse()
            {
                Data = this.mapper.Map<ModelUser>(user)
            };
        }
    }
}