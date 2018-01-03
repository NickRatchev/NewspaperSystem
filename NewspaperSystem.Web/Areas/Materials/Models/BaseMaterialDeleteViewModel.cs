namespace NewspaperSystem.Web.Areas.Materials.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping;
    using NewspaperSystem.Services.Materials.Models;

    public class BaseMaterialDeleteViewModel : IMapFrom<BaseMaterialServiceModel>
    {
        public int Id { get; set; }
    }
}
