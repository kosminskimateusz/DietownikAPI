using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ApiControllerBase
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        // GET api/products
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
            return await this.HandleRequest<GetProductsRequest, GetProductsResponse>(request);
        }

        // GET api/products/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
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
            return await this.HandleRequest<AddProductRequest, AddProductResponse>(request);
        }

        // PUT api/products/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequest request)
        {
            request.productId = id;
            return await this.HandleRequest<UpdateProductRequest, UpdateProductResponse>(request);
        }

        // DELETE api/products/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var request = new DeleteProductRequest()
            {
                ProductId = id
            };
            return await this.HandleRequestWithoutResponseBody<DeleteProductRequest, DeleteProductResponse>(request);
        }
    }
}