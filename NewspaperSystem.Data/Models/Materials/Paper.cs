namespace NewspaperSystem.Data.Models.Materials
{
    public class Paper : BaseMaterial
    {
        public int PaperTypeId { get; set; }

        public PaperType PaperType { get; set; }
    }
}
