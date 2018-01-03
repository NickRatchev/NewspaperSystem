namespace NewspaperSystem.Services.Materials.Models
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using Common.Mapping;
	using Data.Models.Materials;

    public class BaseMaterialServiceModel 
        : IMapFrom<ColorInk>, IMapFrom<BlackInk>
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public decimal SafetyMargin { get; set; }
    }
}
