namespace NewspaperSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Component
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int MachineDataId { get; set; }

        [Required]
        [Range(DataConstants.ColorPairsMinNumber, DataConstants.ColorPairsMaxNumber)]
        public byte Pairs4Color { get; set; }

        [Required]
        [Range(DataConstants.ColorPairsMinNumber, DataConstants.ColorPairsMaxNumber)]
        public byte Pairs3Color { get; set; }

        [Required]
        [Range(DataConstants.ColorPairsMinNumber, DataConstants.ColorPairsMaxNumber)]
        public byte Pairs2Color { get; set; }

        [Required]
        [Range(DataConstants.ColorPairsMinNumber, DataConstants.ColorPairsMaxNumber)]
        public byte Pairs1Color { get; set; }


        public Order Order { get; set; }

        public MachineData MachineData { get; set; }
    }
}
