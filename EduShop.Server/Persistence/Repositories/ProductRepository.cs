using EduShop.Server.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EduShop.Server.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task<Product[]> GetAllAsync(CancellationToken cancellationToken);
    }

    internal class ProductRepository(DatabaseContext context) : IProductRepository
    {
        public Task<Product[]> GetAllAsync(CancellationToken cancellationToken)
        {
            return context.Products.ToArrayAsync(cancellationToken);
        }
    }
}
