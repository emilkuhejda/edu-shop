using Microsoft.AspNetCore.Components;

namespace EduShop.Client.Pages
{
    public partial class ProductDetail
    {
        [Parameter]
        public Guid? ProductId { get; set; }
    }
}
