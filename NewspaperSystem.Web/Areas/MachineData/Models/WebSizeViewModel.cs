namespace NewspaperSystem.Web.Areas.MachineData.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping;
    using Data;
    using NewspaperSystem.Services.MachineData.Models;

    public class WebSizeViewModel : IMapFrom<WebSizeServiceModel>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.WebNameLength)]
        public string WebName { get; set; }

        [Required]
        [Range(DataConstants.MinWebWidth, DataConstants.MaxWebWidth)]
        public int WebWidth { get; set; }       // mm
    }
}
