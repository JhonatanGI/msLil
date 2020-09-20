using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using msLil.Sales.DAL;

namespace msLil.Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesProvider _salesProvider;
        public SalesController(ISalesProvider salesProvider)
        {
            _salesProvider = salesProvider;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            var result = await _salesProvider.GetAsync(customerId);
            if(result != null && result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}