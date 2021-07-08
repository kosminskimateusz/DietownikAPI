using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Products
{
    public class DeleteProductCommand : CommandBase<EntityProduct, EntityProduct>
    {
        public override async Task<EntityProduct> Execute(RecipeStorageContext context)
        {
            context.Products.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}