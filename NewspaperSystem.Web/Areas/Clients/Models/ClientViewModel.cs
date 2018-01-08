namespace NewspaperSystem.Web.Areas.Clients.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping;
    using Data;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using NewspaperSystem.Services.Clients.Models;

    public class ClientViewModel : IMapFrom<ClientServiceModel>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.CompanyNameMaxLength, MinimumLength = DataConstants.CompanyNameMinLength)]

        public string CompanyName { get; set; }

        [Required]
        [StringLength(DataConstants.VatMaxLength, MinimumLength = DataConstants.VatMinLength)]
        public string VatNumber { get; set; }

        [Required]
        [MaxLength(DataConstants.AddressMaxLength)]
        public string Address { get; set; }

        [Required]
        [MaxLength(DataConstants.ContactPersonMaxLength)]
        public string ContactPerson { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int TownId { get; set; }

        public IList<SelectListItem> Towns { get; set; } = new List<SelectListItem>();

    }
}
