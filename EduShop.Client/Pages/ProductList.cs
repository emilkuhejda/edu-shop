using EduShop.Client.Http;
using EduShop.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace EduShop.Client.Pages
{
    public partial class ProductList
    {
        [Inject]
        private IWebClient WebClient { get; set; } = null!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        private ICollection<ProductDto>? Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadProductsAsync();

            await base.OnInitializedAsync();
        }

        private void GoToCreate()
        {
            NavigationManager.NavigateTo("/products/detail");
        }

        private async Task LoadProductsAsync()
        {
            Products = await WebClient.GetProductsAsync();
        }
    }
}
