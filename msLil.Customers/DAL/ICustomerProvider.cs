using System.Threading.Tasks;
using msLil.Customers.Models;

namespace msLil.Customers.DAL
{
    public interface ICustomerProvider
    {
        Task<Customer> GetAsync(string Id);
    }
}