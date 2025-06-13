namespace EduShop.Shared.Contracts
{
    public class CreateOrUpdateProductContract
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}
