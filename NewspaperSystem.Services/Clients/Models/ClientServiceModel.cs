namespace NewspaperSystem.Services.Clients.Models
{
    using Common.Mapping;
    using Data.Models;

    public class ClientServiceModel : IMapFrom<Client>
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string VatNumber { get; set; }

        public string Address { get; set; }

        public string ContactPerson { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public int TownId { get; set; }
    }
}
