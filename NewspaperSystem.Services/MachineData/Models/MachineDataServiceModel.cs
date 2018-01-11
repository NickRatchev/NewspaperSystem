namespace NewspaperSystem.Services.MachineData.Models
{
    public class MachineDataServiceModel
    {
        public int Id { get; set; }

        public byte NumberOfPages { get; set; }

        public byte M1NumberOfPages { get; set; }

        public byte M2NumberOfPages { get; set; }

        public int Web1Id { get; set; }

        public int Web2Id { get; set; }

        public byte ProductionFactor { get; set; }

        public int BaseSpeed { get; set; }
    }
}
