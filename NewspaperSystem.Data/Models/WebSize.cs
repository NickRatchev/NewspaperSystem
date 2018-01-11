namespace NewspaperSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class WebSize
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.WebNameLength)]
        public string WebName { get; set; }

        [Required]
        [Range(DataConstants.MinWebWidth, DataConstants.MaxWebWidth)]
        public int WebWidth { get; set; }       // mm

        public List<MachineData> MachineDatas { get; set; } = new List<MachineData>();
    }
}
