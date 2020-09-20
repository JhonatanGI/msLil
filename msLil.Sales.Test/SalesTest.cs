using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using msLil.Sales.Controllers;
using msLil.Sales.DAL;
using System;
using System.Threading.Tasks;
using Xunit;

namespace msLil.Sales.Test
{
    public class SalesTest
    {
        [Fact]
        public async Task GetAsyncReturnOk()
        {
            var salesProvider = new SalesProvider();
            var salesController = new SalesController(salesProvider);
            var result = await salesController.GetAsync("2");

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, (result as OkObjectResult).StatusCode);

        }
        [Fact]
        public async Task GetAsyncReturnNotFound()
        {
            var salesProvider = new SalesProvider();
            var salesController = new SalesController(salesProvider);
            var result = await salesController.GetAsync("15");

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
        }
    }
}
