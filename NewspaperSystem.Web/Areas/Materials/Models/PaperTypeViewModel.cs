namespace NewspaperSystem.Web.Areas.Materials.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping;
    using Data;
    using NewspaperSystem.Services.Materials.Models;

    public class PaperTypeViewModel : IMapFrom<PaperTypeListServiceModel>
    {
        [Required]
        [StringLength(DataConstants.PaperNameMaxLength, MinimumLength = DataConstants.PaperNameMinLength)]
        public string Name { get; set; }

        [Required]
        [Range(DataConstants.PaperMinGrammage, DataConstants.PaperMaxGrammage)]
        public decimal Grammage { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
