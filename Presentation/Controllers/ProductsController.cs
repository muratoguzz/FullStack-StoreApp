using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ProductsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok( _manager.ProductService.GetAllProducts(false));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneProduct([FromRoute] int id) 
        {
            return Ok(_manager.ProductService.GetOneProduct(id, false));
        }
    }
}