using EduShop.Server.Persistence.Models;

namespace EduShop.Server.Persistence.Repositories
{
    public interface IProductRepository : IRepository<Product>;

    internal class ProductRepository(DatabaseContext context) : Repository<Product>(context), IProductRepository;
}
