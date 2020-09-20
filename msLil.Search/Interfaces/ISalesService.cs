using System.Collections.Generic;
using System.Threading.Tasks;
using msLil.Search.Models;

namespace msLil.Search.Interfaces
{
    public interface ISalesService
    {
        Task<ICollection<Order>> GetAsync(string customerId);
    }
}