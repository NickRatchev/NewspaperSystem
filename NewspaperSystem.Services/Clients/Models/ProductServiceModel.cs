namespace NewspaperSystem.Services.Clients.Models
{
    public class ProductServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal DefaultDiscount { get; set; }

        public bool IsActive { get; set; }

        public int ClientId { get; set; }

        public string ClientName { get; set; }
    }
}
