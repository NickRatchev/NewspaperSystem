namespace NewspaperSystem.Services.Identity
{
    using Services;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IIdentityService : IService
    {
        Task<IEnumerable<IdentityListUserServiceModel>> AllUsersAsync();
    }
}
