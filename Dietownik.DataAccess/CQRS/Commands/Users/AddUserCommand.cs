using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Users
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(RecipeStorageContext context)
        {
            await context.Users.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}