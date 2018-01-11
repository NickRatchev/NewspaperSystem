namespace NewspaperSystem.Data.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PaperWaste
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Range(0.0, DataConstants.PaperWasteMaxNumber)]
        [Column(TypeName = DataConstants.PercentageDecimalPrecisionScale)]
        public decimal CoreWaste { get; set; }       // Percentage

        [Required]
        [Range(0.0, DataConstants.PaperWasteMaxNumber)]
        [Column(TypeName = DataConstants.PercentageDecimalPrecisionScale)]
        public decimal PrintingWaste { get; set; }   // Percentage

        [Required]
        [Range(0.0, int.MaxValue)]
        public int Key1 { get; set; }                // Number of pages (Up to)

        [Required]
        [Range(0.0, DataConstants.PaperWasteMaxNumber)]
        [Column(TypeName = DataConstants.PercentageDecimalPrecisionScale)]
        public decimal Value1 { get; set; }          // Percentage

        [Required]
        [Range(0.0, int.MaxValue)]
        public int Key2 { get; set; }

        [Required]
        [Range(0.0, DataConstants.PaperWasteMaxNumber)]
        [Column(TypeName = DataConstants.PercentageDecimalPrecisionScale)]
        public decimal Value2 { get; set; }

        [Required]
        [Range(0.0, int.MaxValue)]
        public int Key3 { get; set; }

        [Required]
        [Range(0.0, DataConstants.PaperWasteMaxNumber)]
        [Column(TypeName = DataConstants.PercentageDecimalPrecisionScale)]
        public decimal Value3 { get; set; }

        [Required]
        [Range(0.0, int.MaxValue)]
        public int Key4 { get; set; }

        [Required]
        [Range(0.0, DataConstants.PaperWasteMaxNumber)]
        [Column(TypeName = DataConstants.PercentageDecimalPrecisionScale)]
        public decimal Value4 { get; set; }

        [Required]
        [Range(0.0, int.MaxValue)]
        public int Key5 { get; set; }

        [Required]
        [Range(0.0, DataConstants.PaperWasteMaxNumber)]
        [Column(TypeName = DataConstants.PercentageDecimalPrecisionScale)]
        public decimal Value5 { get; set; }
    }
}
