namespace NewspaperSystem.Data.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

    public class ServicePrice
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = "money")]
        public decimal PlateExposing { get; set; }  // For 1 plate

        [Required]
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = "money")]
        public decimal MachineSetup { get; set; }   // For 1 machine

        [Required]
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = "money")]
        public decimal Impression { get; set; }     // For Single production

        [Required]
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = "money")]
        public decimal Packing { get; set; }        // For 1000 pages
    }
}
