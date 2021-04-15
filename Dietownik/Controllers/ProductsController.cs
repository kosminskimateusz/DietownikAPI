using System.Threading.Tasks;
using Dietownik.ApplicationServices.API.Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ApiControllerBase
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
            return await this.HandleRequest<GetProductsRequest, GetProductsResponse>(request);
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute] int productId)
        {
            var request = new GetProductByIdRequest()
            {
                ProductId = productId
            };
            return await this.HandleRequest<GetProductByIdRequest, GetProductByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            return await this.HandleRequest<AddProductRequest, AddProductResponse>(request);
        }

        [HttpPut]
        [Route("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] UpdateProductRequest request)
        {
            request.productId = productId;
            return await this.HandleRequest<UpdateProductRequest, UpdateProductResponse>(request);
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            var request = new DeleteProductRequest()
            {
                ProductId = productId
            };
            return await this.HandleRequestWithoutResponseBody<DeleteProductRequest, DeleteProductResponse>(request);
        }
    }
}