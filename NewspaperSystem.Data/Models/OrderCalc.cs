using System.ComponentModel.DataAnnotations.Schema;

namespace NewspaperSystem.Data.Models
{
    public class OrderCalc
    {
        public int Id { get; set; }

        // Material quantities
        [Column(TypeName = DataConstants.QuantityDecimalPrecisionScale)]
        public decimal PaperKg { get; set; }

        [Column(TypeName = DataConstants.QuantityDecimalPrecisionScale)]
        public decimal PaperWasteKg { get; set; }

        [Column(TypeName = DataConstants.QuantityDecimalPrecisionScale)]
        public decimal BlackInkKg { get; set; }

        [Column(TypeName = DataConstants.QuantityDecimalPrecisionScale)]
        public decimal ColorInksKg { get; set; }

        [Column(TypeName = DataConstants.QuantityDecimalPrecisionScale)]
        public decimal WischwasserKg { get; set; }

        [Column(TypeName = DataConstants.QuantityDecimalPrecisionScale)]
        public decimal FoilKg { get; set; }

        [Column(TypeName = DataConstants.QuantityDecimalPrecisionScale)]
        public decimal TapeMeters { get; set; }

        public int Plates { get; set; }

        public int Blinds { get; set; }


        // Material prices

        [Column(TypeName = "money")]
        public decimal PaperPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal PaperWastePrice { get; set; }

        [Column(TypeName = "money")]
        public decimal BlackInkPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal ColorInksPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal WischwasserPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal FoilPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal TapePrice { get; set; }

        [Column(TypeName = "money")]
        public decimal PlatesPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal BlindsPrice { get; set; }


        // Service prices
        [Column(TypeName = "money")]
        public decimal PlateExposingPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal MachineSetupPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal PrintingPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal PackingPrice { get; set; }


        // To Do - Total Production time


        // Navigation property
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
