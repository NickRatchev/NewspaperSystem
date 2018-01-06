namespace NewspaperSystem.Web.Areas.Materials.Models
{
    using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using Common.Mapping;
	using Microsoft.AspNetCore.Mvc.Rendering;
    using NewspaperSystem.Services.Materials.Models;

    public class PaperViewModel : IMapFrom<PaperServiceModel>
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int PaperTypeId { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0.0, 100.0)]
        public decimal SafetyMargin { get; set; }

        public IList<SelectListItem> PaperTypes { get; set; } = new List<SelectListItem>();
    }
}
