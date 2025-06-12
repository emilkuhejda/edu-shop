using EduShop.Server.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EduShop.Server.Persistence
{
    public class DatabaseContext(
        DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; } = null!;
    }
}
