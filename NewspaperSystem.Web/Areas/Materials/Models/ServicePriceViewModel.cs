using System;

namespace NewspaperSystem.Web.Areas.Materials.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping;
    using Data.Models;

    public class ServicePriceViewModel : IMapFrom<ServicePriceServiceModel>
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal PlateExposing { get; set; }  // For 1 plate

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal MachineSetup { get; set; }   // For 1 machine

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Impression { get; set; }     // For Single production

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Packing { get; set; }        // For 1000 pages
    }
}
