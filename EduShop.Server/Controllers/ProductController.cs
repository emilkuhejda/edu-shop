using Microsoft.AspNetCore.Mvc;

namespace EduShop.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return Ok();
        }
    }
}
