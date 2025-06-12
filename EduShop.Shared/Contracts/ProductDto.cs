namespace EduShop.Shared.Contracts
{
    public record ProductDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;

        public decimal Price { get; init; }

        public int Amount { get; init; }

        public DateTime DateCreated { get; init; }
    }
}
