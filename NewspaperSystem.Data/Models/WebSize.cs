namespace NewspaperSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class WebSize
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.WebNameLength)]
        public string WebName { get; set; }

        [Required]
        [Range(DataConstants.MinWebWidth, DataConstants.MaxWebWidth)]
        public int WebWidth { get; set; }
    }
}
