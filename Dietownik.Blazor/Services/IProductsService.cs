using Dietownik.Blazor.Models;

namespace Dietownik.Blazor.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAll();
    }
}
