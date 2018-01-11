namespace NewspaperSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MachineData
    {
        public int Id { get; set; }

        [Required]
        [Range(0, DataConstants.MaxNumberOfPages)]
        public byte NumberOfPages { get; set; }

        [Required]
        [Range(0, DataConstants.MaxNumberOfPages)]
        public byte M1NumberOfPages { get; set; }

        [Required]
        [Range(0, DataConstants.MaxNumberOfPages)]
        public byte M2NumberOfPages { get; set; }

        [Required]
        public int Web1Id { get; set; }

        [Required]
        public int Web2Id { get; set; }

        [Required]
        [Range(0, DataConstants.MaxProductionFactor)]
        public byte ProductionFactor { get; set; }

        [Required]
        public int BaseSpeed { get; set; }

        public WebSize Web1 { get; set; }

        public WebSize Web2 { get; set; }

        public List<Component> Components { get; set; } = new List<Component>();
    }
}
