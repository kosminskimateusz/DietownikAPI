using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Users
{
    public class GetUsersRequest : IRequest<GetUsersResponse>
    {
        public string SearchUsername { get; set; }
    }
}