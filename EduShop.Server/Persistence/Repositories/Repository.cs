using EduShop.Server.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EduShop.Server.Persistence.Repositories
{
    internal abstract class Repository<T>(DatabaseContext context) : IRepository<T>, IDisposable
        where T : EntityBase
    {
        protected DatabaseContext Context { get; } = context;

        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(T[] entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
        }

        public T Update(T entity)
        {
            Context.Set<T>().Update(entity);
            return entity;
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(T[] entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public Task<T?> GetAsync(Guid entityId, CancellationToken cancellationToken)
        {
            return Context.Set<T>().SingleOrDefaultAsync(x => x.Id == entityId, cancellationToken);
        }

        public Task<T[]> GetAllAsync(CancellationToken cancellationToken)
        {
            return Context.Set<T>().ToArrayAsync(cancellationToken);
        }

        public Task SaveAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }
    }
}
