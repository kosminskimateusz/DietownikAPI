using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Products
{
    public class UpdateProductCommand : CommandBase<EntityProduct, EntityProduct>
    {
        public override async Task<EntityProduct> Execute(RecipeStorageContext context)
        {
            context.Products.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}