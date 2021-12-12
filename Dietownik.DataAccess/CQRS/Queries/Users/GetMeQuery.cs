using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Users
{
    public class GetMeQuery : QueryBase<EntityUser>
    {
        public int Id { get; set; }
        public override Task<EntityUser> Execute(RecipeStorageContext context)
        {
            return context.Users.FirstOrDefaultAsync(user => user.Id == this.Id);
        }
    }
}