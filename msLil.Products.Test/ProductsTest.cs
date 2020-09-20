using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using msLil.Products.Controllers;
using msLil.Products.DAL;
using System.Threading.Tasks;
using Xunit;

namespace msLil.Products.Test
{
    public class ProductsTest
    {
        [Fact]
        public async Task GetAsyncReturnOk()
        {
            var productsProvider = new ProductsProvider();
            var productsController = new ProductsController(productsProvider);
            var result = await productsController.GetAsync("2");

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, (result as OkObjectResult).StatusCode);

        }
        [Fact]
        public async Task GetAsyncReturnNotFound()
        {
            var productsProvider = new ProductsProvider();
            var productsController = new ProductsController(productsProvider);
            var result = await productsController.GetAsync("800");

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
        }
    }
}
