using EduShop.Client.Http;
using EduShop.Shared.Contracts;
using Microsoft.AspNetCore.Components;

namespace EduShop.Client.Pages
{
    public partial class ProductDetail
    {
        [Parameter]
        public Guid? ProductId { get; set; }

        [Inject]
        private IWebClient WebClient { get; set; } = null!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        private CreateOrUpdateProductContract Contract { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            if (ProductId.HasValue)
            {
                var product = await WebClient.GetProductAsync(ProductId.Value);
                Contract = new CreateOrUpdateProductContract
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Amount = product.Amount
                };
            }

            await base.OnInitializedAsync();
        }

        private async Task Save()
        {
            if (ProductId.HasValue)
            {
                await WebClient.UpdateProductAsync(ProductId.Value, Contract);
            }
            else
            {
                await WebClient.CreateProductAsync(Contract);
            }

            NavigationManager.NavigateTo("/products");
        }
    }
}
