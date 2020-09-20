using System.Threading.Tasks;
using msLil.Search.Models;

namespace msLil.Search.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetAsync(string id);
    }
}