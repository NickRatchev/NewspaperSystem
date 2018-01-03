namespace NewspaperSystem.Services.Identity.Models
{
    using System.Collections.Generic;
    using Common.Mapping;
    using Data.Models;

    public class IdentityListUserServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
