using EduShop.Server.Persistence.Models;
using EduShop.Shared.Contracts;
using EduShop.Shared.Dtos;

namespace EduShop.Server.Mappers
{
    internal static class ProductMapper
    {
        public static Product ToProduct(CreateOrUpdateProductContract contract)
        {
            return new Product
            {
                Name = contract.Name,
                Description = contract.Description,
                Price = contract.Price,
                Amount = contract.Amount
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
