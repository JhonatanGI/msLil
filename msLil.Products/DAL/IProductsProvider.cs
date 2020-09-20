using msLil.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msLil.Products.DAL
{
    public interface IProductsProvider
    {
        Task<Product> GetAsync(string Id);
    }
}
