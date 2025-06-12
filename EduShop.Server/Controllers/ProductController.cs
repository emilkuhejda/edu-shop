using EduShop.Server.Mappers;
using EduShop.Server.Persistence;
using EduShop.Shared.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduShop.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(DatabaseContext databaseContext) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ProductDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var products = await databaseContext.Products.ToArrayAsync(cancellationToken);
            return Ok(products.Select(ProductMapper.ToDto));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertAsync(ProductDto productDto, CancellationToken cancellationToken)
        {
            var product = ProductMapper.ToProduct(productDto);
            await databaseContext.Products.AddAsync(product, cancellationToken);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return Ok(ProductMapper.ToDto(product));
        }
    }
}
