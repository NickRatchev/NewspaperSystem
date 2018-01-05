namespace NewspaperSystem.Services.Materials.Models
{
	using System;

    public class PaperServiceModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int PaperTypeId { get; set; }

        public string PaperTypeName { get; set; }

        public decimal Price { get; set; }

        public decimal SafetyMargin { get; set; }
    }
}
