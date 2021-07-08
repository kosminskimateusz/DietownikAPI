using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Users
{
    public class GetUserQuery : QueryBase<EntityUser>
    {
        public string Username { get; set; }
        public override Task<EntityUser> Execute(RecipeStorageContext context)
        {
            return context.Users.FirstOrDefaultAsync(user => user.Username == this.Username);
        }
    }
}