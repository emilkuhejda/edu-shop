namespace EduShop.Server.Persistence.Models
{
    public class Product : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}
