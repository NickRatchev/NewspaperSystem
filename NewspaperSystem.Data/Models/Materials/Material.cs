namespace NewspaperSystem.Data.Models.Materials
{
	using System;

    public abstract class Material : IMaterial
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public decimal SafetyMargin { get; set; }
    }
}
