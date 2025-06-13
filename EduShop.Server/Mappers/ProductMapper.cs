using EduShop.Server.Persistence.Models;
using EduShop.Shared.Contracts;

namespace EduShop.Server.Mappers
{
    internal static class ProductMapper
    {
        public static Product ToProduct(ProductDto dto)
        {
            return new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Amount = dto.Amount,
                DateCreated = dto.DateCreated,
                DateUpdated = dto.DateUpdated
            };
        }

        public static ProductDto ToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Amount = product.Amount,
                DateCreated = product.DateCreated,
                DateUpdated = product.DateUpdated
            };
        }
    }
}
