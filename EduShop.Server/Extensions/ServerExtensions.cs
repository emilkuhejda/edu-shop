using EduShop.Server.Persistence;
using EduShop.Server.Persistence.Models;

namespace EduShop.Server.Extensions
{
    internal static class ServerExtensions
    {
        public static async Task SeedAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            await using var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            var products = new List<Product>
            {
                new()
                {
                    Name = "Item 1",
                    Description = "Description 1",
                    Price = 10,
                    Amount = 100,
                    DateCreated = DateTime.Now
                },
                new()
                {
                    Name = "Item 2",
                    Description = "Description 2",
                    Price = 11,
                    Amount = 110,
                    DateCreated = DateTime.Now
                }
            };

            await databaseContext.Products.AddRangeAsync(products);
            await databaseContext.SaveChangesAsync();
        }
    }
}
