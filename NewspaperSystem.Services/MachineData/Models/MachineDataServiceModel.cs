namespace NewspaperSystem.Services.MachineData.Models
{
    using Common.Mapping;
    using Data.Models;

    public class MachineDataServiceModel : IMapFrom<MachineData>
    {
        public int Id { get; set; }

        public byte NumberOfPages { get; set; }

        public byte M1NumberOfPages { get; set; }

        public byte M2NumberOfPages { get; set; }

        public int Web1Id { get; set; }

        public string Web1Name { get; set; }

        public int Web2Id { get; set; }

        public string Web2Name { get; set; }

        public byte ProductionFactor { get; set; }

        public int BaseSpeed { get; set; }
    }
}
