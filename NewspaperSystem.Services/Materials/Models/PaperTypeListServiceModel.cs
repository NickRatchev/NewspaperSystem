namespace NewspaperSystem.Services.Materials.Models
{
    using Common.Mapping;
    using Data.Models.Materials;

    public class PaperTypeListServiceModel : IMapFrom<PaperType>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Grammage { get; set; }

        public bool IsActive { get; set; }
    }
}
