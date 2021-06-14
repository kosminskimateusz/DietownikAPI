using System.Collections.Generic;
using System.Linq;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Users
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public string SearchUsername { get; set; }
        public override System.Threading.Tasks.Task<List<User>> Execute(RecipeStorageContext context)
        {
            var users = context.Users.ToListAsync();
            if (this.SearchUsername == null)
            {
                return users;
            }
            return context.Users.Where(user => user.Username.Contains(this.SearchUsername)).ToListAsync();
        }
    }
}