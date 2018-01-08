namespace NewspaperSystem.Tests.Mocks
{
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using NewspaperSystem.Data.Models;

    public class UserManagerMock
    {
        public static Mock<UserManager<User>> GetNew()
        {
            IUserStore<User> userStoreMock = Mock.Of<IUserStore<User>>();

            return new Mock<UserManager<User>>(
                userStoreMock, null, null, null, null, null, null, null, null);
        }
    }
}
