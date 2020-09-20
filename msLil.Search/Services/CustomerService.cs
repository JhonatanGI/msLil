using msLil.Search.Interfaces;
using msLil.Search.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace msLil.Search.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Customer> GetAsync(string id)
        {
            var client = _httpClientFactory.CreateClient("customersService");
            var response = await client.GetAsync($"api/customers/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var customer = JsonConvert.DeserializeObject<Customer>(content);
                return customer;
            }
            return null;
        }
    }
}
