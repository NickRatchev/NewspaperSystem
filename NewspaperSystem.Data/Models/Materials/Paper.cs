namespace NewspaperSystem.Data.Models.Materials
{
    public class Paper : Material
    {
        public int PaperTypeId { get; set; }

        public PaperType PaperType { get; set; }
    }
}
