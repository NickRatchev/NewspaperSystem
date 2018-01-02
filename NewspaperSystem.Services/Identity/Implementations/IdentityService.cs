namespace NewspaperSystem.Services.Identity.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class IdentityService : IIdentityService
    {
        private readonly NewspaperSystemDbContext db;

        public IdentityService(NewspaperSystemDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<IdentityListUserViewModel> AllUsers()
        {
            var result = this.db
                .Users
                .ProjectTo<IdentityListUserViewModel>()
                .ToList()
                .OrderBy(u=>u.Username);

            return result;
        }
    }
}
