namespace NewspaperSystem.Web.Areas.Materials.Models
{
    using Common.Mapping;
    using Data.Models;
    public class ServicePriceDeleteViewModel : IMapFrom<ServicePriceServiceModel>
    {
        public int Id { get; set; }
    }
}
