namespace NewspaperSystem.Data.Models.Materials
{
	using System;

    public interface IMaterial
    {
        int Id { get; set; }

        DateTime Date { get; set; }

        decimal Price { get; set; }

        decimal SafetyMargin { get; set; }
    }
}
