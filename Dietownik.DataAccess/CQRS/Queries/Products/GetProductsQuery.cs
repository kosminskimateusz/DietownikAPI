using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Products
{
    public class GetProductsQuery : QueryBase<List<Product>>
    {
        public string SearchPhrase { get; set; }
        public override Task<List<Product>> Execute(RecipeStorageContext context)
        {
            if(this.SearchPhrase == null)
            {
                return context.Products.ToListAsync();
            }
            return context.Products.Where(product => product.Name.Contains(this.SearchPhrase)).ToListAsync();
        }
    }
}