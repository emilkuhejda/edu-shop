using EduShop.Server.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EduShop.Server.Persistence
{
    public class DatabaseContext(
        DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateCreated = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.DateUpdated = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
