using EduShop.Shared.Contracts;
using Newtonsoft.Json;

namespace EduShop.Client.Http
{
    public interface IWebClient
    {
        Task<ProductDto[]> GetProductsAsync(CancellationToken cancellationToken);
    }

    internal class WebClient(IHttpClientFactory clientFactory) : IWebClient
    {
        public async Task<ProductDto[]> GetProductsAsync(CancellationToken cancellationToken)
        {
            var client = clientFactory.CreateClient(nameof(WebClient));
            var response = await client.GetAsync("product", cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<ProductDto[]>(content) ?? [];
        }
    }
}
