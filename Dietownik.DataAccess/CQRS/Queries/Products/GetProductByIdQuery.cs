using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries.Products
{
    public class GetProductByIdQuery : QueryBase<EntityProduct>
    {
        public int Id { get; set; }
        public async override Task<EntityProduct> Execute(RecipeStorageContext context)
        {
            var product = await context.Products.FirstOrDefaultAsync(product => product.Id == this.Id);
            // Added EntityState.Detached for check in Delete Handler that entity exists and if yes than execute Delete command
            if (product != null)
                context.Entry(product).State = EntityState.Detached;
            return product;
        }
    }
}