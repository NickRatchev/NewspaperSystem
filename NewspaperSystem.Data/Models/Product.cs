namespace NewspaperSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.ProductTitleMinLength)]
        [MaxLength(DataConstants.ProductTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public decimal DefaultDiscount { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
