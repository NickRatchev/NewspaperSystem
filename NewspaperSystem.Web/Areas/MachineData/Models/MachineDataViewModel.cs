namespace NewspaperSystem.Web.Areas.MachineData.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data;
    using System.Collections.Generic;
    using Common.Mapping;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using NewspaperSystem.Services.MachineData.Models;

    public class MachineDataViewModel : IMapFrom<MachineDataServiceModel>
    {
        public int Id { get; set; }

        [Required]
        [Range(0, DataConstants.MaxNumberOfPages)]
        public byte NumberOfPages { get; set; }

        [Required]
        [Range(0, DataConstants.MaxNumberOfPages)]
        public byte M1NumberOfPages { get; set; }

        [Required]
        [Range(0, DataConstants.MaxNumberOfPages)]
        public byte M2NumberOfPages { get; set; }

        [Required]
        public int Web1Id { get; set; }

        public string Web1Name { get; set; }

        [Required]
        public int Web2Id { get; set; }

        public string Web2Name { get; set; }

        [Required]
        [Range(0, DataConstants.MaxProductionFactor)]
        public byte ProductionFactor { get; set; }

        [Required]
        [Range(0, DataConstants.MaxBaseSpeed)]
        public int BaseSpeed { get; set; }

        public IList<SelectListItem> WebSizes { get; set; } = new List<SelectListItem>();
    }
}
