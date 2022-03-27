using System.Threading.Tasks;
using ProductsApi.Models;
using System.Collections.Generic;

namespace ProductsApi.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetAll();
        Task Add(Product product);
        Task Delete(int id);
        Task Update(Product pr);

    }
}