using EduShop.Shared.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EduShop.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ProductDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllAsync(CancellationToken cancellationToken)
        {
            var products = new List<ProductDto>
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

            return Ok(products);
        }
    }
}
