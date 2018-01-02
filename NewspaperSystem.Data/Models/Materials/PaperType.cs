namespace NewspaperSystem.Data.Models.Materials
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PaperType
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.PaperNameMinLength)]
        [MaxLength(DataConstants.PaperNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(DataConstants.PaperMinGrammage, DataConstants.PaperMaxGrammage)]
        public decimal Grammage { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public List<Paper> PaperPrices { get; set; } = new List<Paper>();

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
