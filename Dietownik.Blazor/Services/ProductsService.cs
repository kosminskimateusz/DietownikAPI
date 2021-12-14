using Dietownik.Blazor.Models;

namespace Dietownik.Blazor.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IhttpService httpService;

        public ProductsService(IhttpService httpService)
        {
            this.httpService = httpService;
        }
        public Task<IEnumerable<Product>> GetAll()
        {
            return httpService.Get<IEnumerable<Product>>("/products");
        }
    }
}
