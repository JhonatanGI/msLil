using msLil.Products.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msLil.Products.DAL
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly IEnumerable<Product> products;
        public ProductsProvider()
        {
            products = Enumerable.Range(1, 100).Select(s => new Product
            {
                Id = s.ToString(),
                Name = $"Product{s}",
                Price = (double)s*3.1416
            });
        }

        public Task<Product> GetAsync(string Id)
        {
            var product = products.FirstOrDefault(p => p.Id.Equals(Id));
            return Task.FromResult(product);
        }
    }
}
