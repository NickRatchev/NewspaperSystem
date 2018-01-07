namespace NewspaperSystem.Services.Clients.Models
{
    using Common.Mapping;
    using Data.Models;

    public class TownServiceModel : IMapFrom<Town>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
