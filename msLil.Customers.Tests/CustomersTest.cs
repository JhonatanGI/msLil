using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using msLil.Customers.Controllers;
using msLil.Customers.DAL;
using System.Threading.Tasks;
using Xunit;

namespace msLil.Customers.Tests
{
    public class CustomersTest
    {
        [Fact]
        public async Task GetAsyncReturnOk()
        {
            var customersProvider = new CustomerProvider();
            var customersController = new CustomersController(customersProvider);
            var result = await customersController.GetAsync("1");

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, (result as OkObjectResult).StatusCode);

        }
        [Fact]
        public async Task GetAsyncReturnNotFound()
        {
            var customersProvider = new CustomerProvider();
            var customersController = new CustomersController(customersProvider);
            var result = await customersController.GetAsync("99");

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
        }
    }
}
