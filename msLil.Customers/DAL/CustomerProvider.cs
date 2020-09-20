using msLil.Customers.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msLil.Customers.DAL
{
    public class CustomerProvider : ICustomerProvider
    {
        private readonly List<Customer> customers = new List<Customer>();
        public CustomerProvider()
        {
            customers.Add(new Customer { Id = "1", Name = "Rodrigo", City = "Medellin" });
            customers.Add(new Customer { Id = "2", Name = "Jhonatan", City = "Cali" });
            customers.Add(new Customer { Id = "3", Name = "Laura", City = "Pasto" });
            customers.Add(new Customer { Id = "4", Name = "Jhohan", City = "Barranquilla" });
            customers.Add(new Customer { Id = "5", Name = "Juan", City = "Bogota" });
        }

        public Task<Customer> GetAsync(string Id)
        {
            var customer = customers.FirstOrDefault(c => c.Id.Equals(Id));
            return Task.FromResult(customer);
        }
    }
}
