namespace NewspaperSystem.Data.Models
{
    using System.Collections.Generic;

    public class MachineData
    {
        public int Id { get; set; }

        public byte NumberOfPages { get; set; }

        public byte M1NumberOfPages { get; set; }

        public byte M2NumberOfPages { get; set; }

        public int Web1Id { get; set; }

        public int Web2Id { get; set; }

        public byte ProductionFactor { get; set; }

        public int BaseSpeed { get; set; }

        public WebSize Web1 { get; set; }

        public WebSize Web2 { get; set; }

        public List<Component> Components { get; set; } = new List<Component>();
    }
}
