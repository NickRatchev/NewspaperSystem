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

        public IEnumerable<IdentityListUserServiceModel> AllUsers()
        {
            var result = this.db
                .Users
                .ProjectTo<IdentityListUserServiceModel>()
                .ToList()
                .OrderBy(u=>u.Username);

            return result;
        }
    }
}
