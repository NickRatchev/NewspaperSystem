namespace NewspaperSystem.Web.Areas.Materials.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping;
    using NewspaperSystem.Services.Materials.Models;

    public class BaseMaterialViewModel : IMapFrom<BaseMaterialServiceModel>
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0.0, 100.0)]
        public decimal SafetyMargin { get; set; }
    }
}
