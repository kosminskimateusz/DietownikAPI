using System.Collections.Generic;
using System.Linq;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Users
{
    public class GetUsersQuery : QueryBase<List<EntityUser>>
    {
        public string SearchUsername { get; set; }
        public override System.Threading.Tasks.Task<List<EntityUser>> Execute(RecipeStorageContext context)
        {
            if (this.SearchUsername == null)
            {
                return context.Users.ToListAsync();
            }
            return context.Users.Where(user => user.Username.Contains(this.SearchUsername)).ToListAsync();
        }
    }
}