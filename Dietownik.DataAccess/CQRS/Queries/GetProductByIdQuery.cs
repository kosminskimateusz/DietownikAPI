using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dietownik.DataAccess.CQRS.Queries
{
    public class GetProductByIdQuery : QueryBase<Product>
    {
        public int Id { get; set; }
        public async override Task<Product> Execute(RecipeStorageContext context)
        {
            var product = await context.Products.FirstOrDefaultAsync(product => product.Id == this.Id);
            return product;
        }
    }
}