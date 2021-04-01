using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands
{
    public class DeleteProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(RecipeStorageContext context)
        {
            var product = new Product { Id = this.Parameter.Id};
            await context.Products.Remove(product);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}