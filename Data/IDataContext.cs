using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ProductsApi.Data
{
    public interface IDataContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}