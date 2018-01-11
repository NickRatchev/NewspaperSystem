namespace NewspaperSystem.Web.Areas.Clients.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping;
    using Data;
    using NewspaperSystem.Services.Clients.Models;

    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.ProductTitleMaxLength, MinimumLength = DataConstants.ProductTitleMinLength)]
        public string Title { get; set; }

        [Required]
        public decimal DefaultDiscount { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int ClientId { get; set; }

        public string ClientName { get; set; }
    }
}
