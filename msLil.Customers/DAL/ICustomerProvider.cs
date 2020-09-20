using msLil.Customers.Models;
using System.Threading.Tasks;

namespace msLil.Customers.DAL
{
    public interface ICustomerProvider
    {
        Task<Customer> GetAsync(string Id);
    }
}