using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Users
{
    public class AddUserCommand : CommandBase<EntityUser, EntityUser>
    {
        public override async Task<EntityUser> Execute(RecipeStorageContext context)
        {
            await context.Users.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}