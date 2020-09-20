using msLil.Search.Interfaces;
using msLil.Search.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace msLil.Search.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Product> GetAsync(string id)
        {
            var client = _httpClientFactory.CreateClient("productsService");
            var response = await client.GetAsync($"api/products/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(content);
                return product;
            }
            return null;
        }
    }
}
