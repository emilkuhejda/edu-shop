using EduShop.Shared.Dtos;
using EduShop.Client.Extensions;

namespace EduShop.Client.Http
{
    public interface IWebClient
    {
        Task<ICollection<ProductDto>> GetProductsAsync();
    }

    internal class WebClient(IHttpClientFactory clientFactory) : IWebClient
    {
        public async Task<ICollection<ProductDto>> GetProductsAsync()
        {
            return await GetClient().SendGetAsync<List<ProductDto>>("/product");
        }
        
        private HttpClient GetClient()
        {
            return clientFactory.CreateClient(nameof(WebClient));
        }
    }
}
