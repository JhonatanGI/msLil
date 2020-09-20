using msLil.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msLil.Search.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetAsync(string id);
    }
}
