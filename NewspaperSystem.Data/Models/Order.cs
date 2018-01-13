namespace NewspaperSystem.Data.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using Materials;

    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ClientId { get; set; }

        [Required]
        public int Issue { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int PaperTypeId { get; set; }

        [Required]
        public int PrintRun { get; set; }

        [Required]
        [Column(TypeName = DataConstants.PercentageDecimalPrecisionScale)]
        public decimal Discount { get; set; }

        public int OrderCalcId { get; set; }


        // To Do - Total Production time


        public Product Product { get; set; }

        public Client Client { get; set; }

        public List<Component> Components { get; set; } = new List<Component>();

        public PaperType PaperType { get; set; }

        public OrderCalc OrderCalc { get; set; }
    }
}
