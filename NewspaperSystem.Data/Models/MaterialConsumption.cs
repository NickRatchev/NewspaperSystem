namespace NewspaperSystem.Data.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MaterialConsumption
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = DataConstants.PageSizeDecimalPrecisionScale)]
        public decimal PageWidth { get; set; }      // mm

        [Required]
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = DataConstants.PageSizeDecimalPrecisionScale)]
        public decimal PageHeight { get; set; }     // mm

        [Required]
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = DataConstants.QuantityDecimalPrecisionScale)]
        public decimal Foil { get; set; }           // Kg for 1000 pages

        [Required]
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = DataConstants.QuantityDecimalPrecisionScale)]
        public decimal Tape { get; set; }           // m for 1000 pages

        [Required]
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = DataConstants.QuantityDecimalPrecisionScale)]
        public decimal Wischwasser { get; set; }    // Kg for 1000 pages

        [Required]
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = DataConstants.QuantityDecimalPrecisionScale)]
        public decimal InkBlack { get; set; }       // Kg for 1000 pages

        [Required]
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = DataConstants.QuantityDecimalPrecisionScale)]
        public decimal InkColor { get; set; }       // Kg for 1000 pages

        [Required]
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = DataConstants.QuantityDecimalPrecisionScale)]
        public decimal PlateDeveloper { get; set; } // l for 1 plate
    }
}
