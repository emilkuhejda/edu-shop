using EduShop.Server.Mappers;
using EduShop.Server.Persistence.Repositories;
using EduShop.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EduShop.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IProductRepository productRepository) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ProductDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync(cancellationToken);
            return Ok(products.Select(ProductMapper.ToDto));
        }
    }
}
