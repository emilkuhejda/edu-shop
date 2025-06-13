using EduShop.Shared.Contracts;
using EduShop.Shared.Dtos;
using EduShop.Client.Extensions;

namespace EduShop.Client.Http
{
    public interface IWebClient
    {
        Task<ICollection<ProductDto>> GetProductsAsync();

        Task<ProductDto> GetProductAsync(Guid productId);

        Task CreateProductAsync(CreateOrUpdateProductContract contract);

        Task UpdateProductAsync(Guid productId, CreateOrUpdateProductContract contract);

        Task DeleteProductAsync(Guid productId);
    }

    internal class WebClient(IHttpClientFactory clientFactory) : IWebClient
    {
        public async Task<ICollection<ProductDto>> GetProductsAsync()
        {
            return await GetClient().SendGetAsync<List<ProductDto>>("/product");
        }

        public async Task<ProductDto> GetProductAsync(Guid productId)
        {
            return await GetClient().SendGetAsync<ProductDto>($"/product/{productId}");
        }

        public async Task CreateProductAsync(CreateOrUpdateProductContract contract)
        {
            await GetClient().SendPostAsync("/product", contract);
        }

        public async Task UpdateProductAsync(Guid productId, CreateOrUpdateProductContract contract)
        {
            await GetClient().SendPutAsync($"/product/{productId}", contract);
        }

        public async Task DeleteProductAsync(Guid productId)
        {
            await GetClient().SendDeleteAsync($"/product/{productId}");
        }

        private HttpClient GetClient()
        {
            return clientFactory.CreateClient(nameof(WebClient));
        }
    }
}
