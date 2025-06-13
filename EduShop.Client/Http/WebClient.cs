using EduShop.Shared.Contracts;
using EduShop.Shared.Dtos;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace EduShop.Client.Http
{
    public interface IWebClient
    {
        Task<ProductDto[]> GetProductsAsync();

        Task<ProductDto> GetProductAsync(Guid productId);

        Task CreateProductAsync(CreateOrUpdateProductContract contract);

        Task UpdateProductAsync(Guid productId, CreateOrUpdateProductContract contract);

        Task DeleteProductAsync(Guid productId);
    }

    internal class WebClient(IHttpClientFactory clientFactory) : IWebClient
    {
        public async Task<ProductDto[]> GetProductsAsync()
        {
            using var cts = new CancellationTokenSource();
            var client = clientFactory.CreateClient(nameof(WebClient));
            var response = await client.GetAsync("product", cts.Token);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cts.Token);
            return JsonConvert.DeserializeObject<ProductDto[]>(content) ?? [];
        }

        public async Task<ProductDto> GetProductAsync(Guid productId)
        {
            using var cts = new CancellationTokenSource();
            var client = clientFactory.CreateClient(nameof(WebClient));
            var response = await client.GetAsync($"product/{productId}", cts.Token);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cts.Token);
            return JsonConvert.DeserializeObject<ProductDto>(content) ?? new ProductDto();
        }

        public async Task CreateProductAsync(CreateOrUpdateProductContract contract)
        {
            using var cts = new CancellationTokenSource();
            var client = clientFactory.CreateClient(nameof(WebClient));
            var response = await client.PostAsJsonAsync("product", contract, cts.Token);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductAsync(Guid productId, CreateOrUpdateProductContract contract)
        {
            using var cts = new CancellationTokenSource();
            var client = clientFactory.CreateClient(nameof(WebClient));
            var response = await client.PutAsJsonAsync($"product/{productId}", contract, cts.Token);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductAsync(Guid productId)
        {
            using var cts = new CancellationTokenSource();
            var client = clientFactory.CreateClient(nameof(WebClient));
            var response = await client.DeleteAsync($"product/{productId}", cts.Token);
            response.EnsureSuccessStatusCode();
        }
    }
}
