﻿namespace NewspaperSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.CompanyNameMinLength)]
        [MaxLength(DataConstants.CompanyNameMaxLength)]
        public string CompanyName { get; set; }

        [Required]
        [MinLength(DataConstants.VatMinLength)]
        [MaxLength(DataConstants.VatMaxLength)]
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

        public Town Town { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
