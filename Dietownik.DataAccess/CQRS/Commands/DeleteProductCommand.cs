using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands
{
    public class DeleteProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(RecipeStorageContext context)
        {
            context.Products.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}