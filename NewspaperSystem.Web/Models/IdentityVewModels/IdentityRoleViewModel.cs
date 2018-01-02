namespace NewspaperSystem.Web.Models.IdentityVewModels
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class IdentityRoleViewModel
    {
        public string Username { get; set; }

        public IList<string> SelectedRoles { get; set; } = new List<string>();

        public IList<SelectListItem> AvailableRoles { get; set; } = new List<SelectListItem>();
    }
}