namespace NewspaperSystem.Web.Areas.Clients.Models
{
    using System.Collections.Generic;
    using NewspaperSystem.Services.Clients.Models;

    public class ProductsClientListViewModel
    {
        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public IEnumerable<ProductServiceModel> Products { get; set; } = new List<ProductServiceModel>();
    }
}
