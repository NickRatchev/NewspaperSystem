namespace NewspaperSystem.Web.Areas.Clients.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping;
    using Data;
    using Data.Models;
    using NewspaperSystem.Services.Clients.Models;

    public class TownViewModel : IMapFrom<TownServiceModel>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.TownNameMaxLength, MinimumLength = DataConstants.TownNameMinLength)]
        public string Name { get; set; }

        public List<Client> Clients { get; set; }
    }
}
