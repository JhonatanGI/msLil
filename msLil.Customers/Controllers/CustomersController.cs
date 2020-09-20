using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using msLil.Customers.DAL;

namespace msLil.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerProvider _customerProvider;
        public CustomersController(ICustomerProvider customerProvider)
        {
            _customerProvider = customerProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string Id)
        {
            var result = await _customerProvider.GetAsync(Id);
            if(result !=  null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}