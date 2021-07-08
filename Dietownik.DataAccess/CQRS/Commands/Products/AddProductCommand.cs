using System.Threading.Tasks;
using Dietownik.DataAccess.Entities;

namespace Dietownik.DataAccess.CQRS.Commands.Products
{
    public class AddProductCommand : CommandBase<EntityProduct, EntityProduct>
    {
        public override async Task<EntityProduct> Execute(RecipeStorageContext context)
        {
            await context.Products.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}