﻿namespace NewspaperSystem.Web.Areas.Materials.Models
{
    using Common.Mapping;
    using NewspaperSystem.Services.Materials.Models;
    public class PaperTypeDeleteViewModel : IMapFrom<PaperTypeServiceModel>
    {
        public int Id { get; set; }
    }
}
