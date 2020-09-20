using Microsoft.AspNetCore.Mvc;
using msLil.Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msLil.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly ISalesService _salesService;
        public SearchController(IProductService productService, ICustomerService customerService, ISalesService salesService)
        {
            _productService = productService;
            _customerService = customerService;
            _salesService = salesService;
        }

        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> SearhAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            try
            {
                var customer = await _customerService.GetAsync(customerId);
                var sales = await _salesService.GetAsync(customerId);
                foreach (var sale in sales)
                {
                    foreach (var item in sale.Items)
                    {
                        var product = await _productService.GetAsync(item.ProducId);
                        item.Product = product;
                    }
                }
                var result = new
                {
                    Customer = customer,
                    Sales = sales
                };
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
