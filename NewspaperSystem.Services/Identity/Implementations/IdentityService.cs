namespace NewspaperSystem.Services.Identity.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class IdentityService : IIdentityService
    {
        private readonly NewspaperSystemDbContext db;

        public IdentityService(NewspaperSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<IdentityListUserServiceModel>> AllUsersAsync()
        {
            var result = await this.db
                .Users
                .ProjectTo<IdentityListUserServiceModel>()
                .OrderBy(u => u.Username)
                .ToListAsync();

            return result;
        }
    }
}
