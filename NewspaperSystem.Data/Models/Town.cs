namespace NewspaperSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.TownNameMinLength)]
        [MaxLength(DataConstants.TownNameMaxLength)]
        public string Name { get; set; }

        public List<Client> Clients { get; set; } = new List<Client>();
    }
}
