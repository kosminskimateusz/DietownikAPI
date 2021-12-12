using MediatR;

namespace Dietownik.ApplicationServices.API.Domain.Users
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        EndUser = 0,
        Admin = 1
    }
}