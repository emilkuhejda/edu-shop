using EduShop.Server.Mappers;
using EduShop.Server.Persistence.Repositories;
using EduShop.Shared.Contracts;
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

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertAsync(ProductDto productDto, CancellationToken cancellationToken)
        {
            var product = ProductMapper.ToProduct(productDto);
            await productRepository.AddAsync(product);
            await productRepository.SaveAsync(cancellationToken);

            return Ok(ProductMapper.ToDto(product));
        }
    }
}
