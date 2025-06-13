namespace EduShop.Server.Persistence.Models
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
