using System.Collections.Generic;
using System.Threading.Tasks;
using msLil.Sales.Models;

namespace msLil.Sales.DAL
{
    public interface ISalesProvider
    {
        Task<ICollection<Order>> GetAsync(string customerId);
    }
}