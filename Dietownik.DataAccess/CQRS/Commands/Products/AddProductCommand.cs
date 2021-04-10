using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Products
{
    public class AddProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(RecipeStorageContext context)
        {
            await context.Products.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}