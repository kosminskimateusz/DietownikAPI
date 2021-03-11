using System.Collections.Generic;
using Dietownik.DataAccess;
using Dietownik.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dietownik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> productRepository;
        public ProductController(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Product> GetAllProducts() => this.productRepository.GetAll();
    }
}