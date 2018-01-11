namespace NewspaperSystem.Services.MachineData.Models
{
    using Common.Mapping;
    using Data.Models;
    public class WebSizeServiceModel : IMapFrom<WebSize>
    {
        public int Id { get; set; }

        public string WebName { get; set; }

        public int WebWidth { get; set; }
    }
}
