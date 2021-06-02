using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ApiControllerBase
    {
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IMediator mediator, ILogger<ProductsController> logger) : base(mediator, logger)
        {
            this.logger = logger;
        }

        // GET api/products
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
            this.logger.LogInformation("Get Products");
            return await this.HandleRequest<GetProductsRequest, GetProductsResponse>(request);
        }

        // GET api/products/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            this.logger.LogInformation($"Get Product with id: {id} .");
            var request = new GetProductByIdRequest()
            {
                ProductId = id
            };
            return await this.HandleRequest<GetProductByIdRequest, GetProductByIdResponse>(request);
        }

        // POST api/products
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            this.logger.LogInformation($"Add Product:  Name\t{request.Name}");
            return await this.HandleRequest<AddProductRequest, AddProductResponse>(request);
        }

        // PUT api/products/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequest request)
        {
            this.logger.LogInformation($"Update Product with id: {id}");
            request.productId = id;
            return await this.HandleRequest<UpdateProductRequest, UpdateProductResponse>(request);
        }

        // DELETE api/products/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            logger.LogInformation($"Delete Product with id: {id}");
            var request = new DeleteProductRequest()
            {
                ProductId = id
            };
            return await this.HandleRequestWithoutResponseBody<DeleteProductRequest, DeleteProductResponse>(request);
        }
    }
}