namespace NewspaperSystem.Data.Models.Materials
{
	using System;
	using System.ComponentModel.DataAnnotations;

    public interface IMaterial
    {
        int Id { get; set; }

        [Required]
        DateTime Date { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        decimal Price { get; set; }

        [Required]
        [Range(0.0, 100.0)]
        decimal SafetyMargin { get; set; }
    }
}
