using EduShop.Server.Mappers;
using EduShop.Server.Persistence.Repositories;
using EduShop.Shared.Contracts;
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

        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(Guid productId, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetAsync(productId, cancellationToken);
            if (product == null)
                return NotFound();

            return Ok(ProductMapper.ToDto(product));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertAsync(CreateOrUpdateProductContract contract, CancellationToken cancellationToken)
        {
            var product = ProductMapper.ToProduct(contract);
            await productRepository.AddAsync(product);
            await productRepository.SaveAsync(cancellationToken);

            return Ok(ProductMapper.ToDto(product));
        }

        [HttpPut("{productId}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(Guid productId, CreateOrUpdateProductContract contract, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetAsync(productId, cancellationToken);
            if (product == null)
                return NotFound();

            product.Name = contract.Name;
            product.Description = contract.Description;
            product.Price = contract.Price;
            product.Amount = contract.Amount;
            await productRepository.SaveAsync(cancellationToken);

            return Ok(ProductMapper.ToDto(product));
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(Guid productId, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetAsync(productId, cancellationToken);
            if (product == null)
                return NotFound();

            productRepository.Remove(product);
            await productRepository.SaveAsync(cancellationToken);
            return NoContent();
        }
    }
}
