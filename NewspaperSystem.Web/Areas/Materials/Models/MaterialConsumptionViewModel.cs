﻿namespace NewspaperSystem.Web.Areas.Materials.Models
{
    using System;
	using System.ComponentModel.DataAnnotations;
	using Common.Mapping;
    using Data.Models;

    public class MaterialConsumptionViewModel : IMapFrom<MaterialConsumptionServiceModel>
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal PageWidth { get; set; }      // mm

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal PageHeight { get; set; }     // mm

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Foil { get; set; }           // Kg for 1000 pages

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Tape { get; set; }           // m for 1000 pages

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Wischwasser { get; set; }    // Kg for 1000 pages

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal InkBlack { get; set; }       // Kg for 1000 pages

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal InkColor { get; set; }       // Kg for 1000 pages

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal PlateDeveloper { get; set; } // l for 1 plate
    }
}
