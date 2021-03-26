using System.Collections.Generic;
using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries
{
    public class GetProductsQuery : QueryBase<List<Product>>
    {
        public override Task<List<Product>> Execute(RecipeStorageContext context)
        {
            return context.Products.ToListAsync();
        }
    }
}