using Domain;
using DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace EB_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return Ok(_productRepository.Products.ToList());
        }
    }
}
