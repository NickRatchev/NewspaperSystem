namespace NewspaperSystem.Data.Models.Materials
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

    public abstract class BaseMaterial
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = DataConstants.PercentageDecimalPrecisionScale)]
        [Range(0.0, 100.0)]
        public decimal SafetyMargin { get; set; }
    }
}
