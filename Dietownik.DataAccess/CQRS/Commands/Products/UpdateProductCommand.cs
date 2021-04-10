using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Products
{
    public class UpdateProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(RecipeStorageContext context)
        {
            context.Products.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}