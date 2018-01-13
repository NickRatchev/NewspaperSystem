namespace NewspaperSystem.Services.Clients.Models
{
    using Common.Mapping;
    using Data.Models;
    public class ProductServiceModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal DefaultDiscount { get; set; }

        public bool IsActive { get; set; }

        public int ClientId { get; set; }

        public string ClientName { get; set; }
    }
}
