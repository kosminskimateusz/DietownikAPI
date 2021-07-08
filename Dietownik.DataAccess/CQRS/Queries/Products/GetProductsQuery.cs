using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Products
{
    public class GetProductsQuery : QueryBase<List<EntityProduct>>
    {
        public string SearchPhrase { get; set; }
        public override Task<List<EntityProduct>> Execute(RecipeStorageContext context)
        {
            if (this.SearchPhrase == null)
            {
                return context.Products.ToListAsync();
            }
            return context.Products.Where(product => product.Name.Contains(this.SearchPhrase)).ToListAsync();
        }
    }
}