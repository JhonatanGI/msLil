using Microsoft.AspNetCore.Mvc;
using msLil.Products.DAL;
using System.Threading.Tasks;

namespace msLil.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider _productsProvider;
        public ProductsController(IProductsProvider productsProvider)
        {
            _productsProvider = productsProvider;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await _productsProvider.GetAsync(id);
            if(result != null)
            {
                return Ok(result);
            }
            await Task.Delay(10);
            return NotFound();
        }
            
    }
}