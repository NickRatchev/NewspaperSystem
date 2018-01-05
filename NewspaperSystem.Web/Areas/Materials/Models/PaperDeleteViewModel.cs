namespace NewspaperSystem.Services.Materials.Models
{
    using Common.Mapping;
    public class PaperDeleteViewModel : IMapFrom<PaperServiceModel>
    {
        public int Id { get; set; }
    }
}
