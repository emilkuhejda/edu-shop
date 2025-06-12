using EduShop.Client.Http;
using EduShop.Shared.Contracts;
using Microsoft.AspNetCore.Components;

namespace EduShop.Client.Pages
{
    public partial class ProductList
    {
        [Inject]
        private IWebClient WebClient { get; set; } = null!;

        public ICollection<ProductDto>? Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            using var cts = new CancellationTokenSource();
            Products = await WebClient.GetProductsAsync(cts.Token);

            await base.OnInitializedAsync();
        }
    }
}
