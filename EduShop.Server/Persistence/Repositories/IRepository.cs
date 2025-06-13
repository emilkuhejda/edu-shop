using EduShop.Server.Persistence.Models;

namespace EduShop.Server.Persistence.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task AddAsync(T entity);

        Task AddRangeAsync(T[] entities);

        T Update(T entity);

        void Remove(T entity);

        void RemoveRange(T[] entities);

        Task<T?> GetAsync(Guid entityId, CancellationToken cancellationToken);

        Task<T[]> GetAllAsync(CancellationToken cancellationToken);

        Task SaveAsync(CancellationToken cancellationToken);
    }
}
