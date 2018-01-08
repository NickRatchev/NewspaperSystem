namespace NewspaperSystem.Services.Identity
{
    using Services;
    using Models;
    using System.Collections.Generic;

    public interface IIdentityService : IService
    {
        IEnumerable<IdentityListUserServiceModel> AllUsers();
    }
}
