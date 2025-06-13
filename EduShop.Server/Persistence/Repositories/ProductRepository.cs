using EduShop.Server.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EduShop.Server.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);

        void Remove(Product product);

        Task<Product?> GetAsync(Guid productId, CancellationToken cancellationToken);

        Task<Product[]> GetAllAsync(CancellationToken cancellationToken);

        Task SaveAsync(CancellationToken cancellationToken);
    }

    internal class ProductRepository(DatabaseContext context) : IProductRepository
    {
        public async Task AddAsync(Product product)
        {
            await context.Products.AddAsync(product);
        }

        public void Remove(Product product)
        {
            context.Products.Remove(product);
        }

        public Task<Product?> GetAsync(Guid productId, CancellationToken cancellationToken)
        {
            return context.Products.SingleOrDefaultAsync(x => x.Id == productId, cancellationToken);
        }

        public Task<Product[]> GetAllAsync(CancellationToken cancellationToken)
        {
            return context.Products.ToArrayAsync(cancellationToken);
        }

        public Task SaveAsync(CancellationToken cancellationToken)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
