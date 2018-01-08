namespace NewspaperSystem.Tests.Web.Areas.Identity.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Models;
    using FluentAssertions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.EntityFrameworkCore;
    using Mocks;
    using Moq;
    using NewspaperSystem.Web;
    using Xunit;
    using NewspaperSystem.Web.Areas.Identity.Controllers;
    using NewspaperSystem.Web.Areas.Identity.Models;
    using NewspaperSystem.Web.Models.AccountViewModels;
    using Services.Identity;
    using Services.Identity.Models;

    public class HomeControllerTests
    {
        private const string FirstUserId = "1";
        private const string FirstUserUsername = "First";
        private const string FirstUserEmail = "first@gmail.com";
        private const string SecondUserId = "2";
        private const string SecondUserUsername = "Second";
        private const string SecondUserEmail = "second@gmail.com";
        private const string InvalidUserId = null;
        private const string EditUserMessageUpdated = "User \"First\" was updated successfuly!";
        private const string ResetPasswordMessageSuccessfull = "Password for user \"First\" was successfuly changed!";
        private const string ManageRolesMessageSuccessfull = "Successfuly changed roles for user \"First\"!";
        private const string AddUserMessageSuccessfull = "User \"First\" was successfuly created!";
        private const string DeleteMessageSuccessfull = "User \"First\" was successfuly deleted!";


        #region Attributes

        [Fact]
        public void HomeController_ShouldBeInIdentityArea()
        {
            // Arrange
            Type controller = typeof(HomeController);

            // Act
            AreaAttribute areaAttribute = controller
                    .GetCustomAttributes(true)
                    .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute))
                as AreaAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.RouteValue.Should().Be(WebConstants.IdentityArea);
        }

        [Fact]
        public void HomeController_ShouldOnlyBeForAdminUsers()
        {
            // Arrange
            Type controller = typeof(HomeController);

            // Act
            AuthorizeAttribute authorizeAttribute = controller
                    .GetCustomAttributes(true)
                    .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute))
                as AuthorizeAttribute;

            // Assert
            authorizeAttribute.Should().NotBeNull();
            authorizeAttribute.Roles.Should().Be(WebConstants.AdministratorRole);
        }

        #endregion

        #region AllUsers

        [Fact]
        public async Task AllUsers_ShouldReturnAllUsersWithSearchTermNUll()
        {
            // Arrange
            Mock<IIdentityService> adminService = new Mock<IIdentityService>();
            adminService
                .Setup(service => service.AllUsersAsync())
                .ReturnsAsync(new List<IdentityListUserServiceModel>()
                {
                        new IdentityListUserServiceModel() { Id = FirstUserId, Email = FirstUserEmail, Username = FirstUserUsername },
                        new IdentityListUserServiceModel() { Id = SecondUserId, Email = SecondUserEmail, Username = SecondUserUsername }
                });

            HomeController controller = new HomeController(adminService.Object, null, null);

            // Act
            IActionResult actionResult = await controller.AllUsers();

            // Assert
            actionResult.Should().BeOfType<ViewResult>();

            var model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<List<IdentityListUserServiceModel>>();

            var returnedModels = model.As<List<IdentityListUserServiceModel>>();

            returnedModels.Should().Match(u => u.As<List<IdentityListUserServiceModel>>().Count() == 2);
            returnedModels.First().Should().Match(u => u.As<IdentityListUserServiceModel>().Id == FirstUserId);
            returnedModels.Last().Should().Match(u => u.As<IdentityListUserServiceModel>().Id == SecondUserId);
        }

        #endregion

        #region Manage Roles

        [Fact]
        public async Task ManageRolesGet_ShouldReturnNotFoundWhenInvalidUserId()
        {
            // Arrange
            Mock<UserManager<User>> userManager = UserManagerMock.GetNew();

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.ManageRoles(InvalidUserId);

            // Assert
            actionResult.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task ManageRolesGet_ShouldReturnViewWithCorrectModelWhenValidUserId()
        {
            // Arrange
            Mock<RoleManager<IdentityRole>> roleManager = GetAndSetRoleManagerMock();

            Mock<UserManager<User>> userManager = GetAndSetUserManagerMock();

            HomeController controller = new HomeController(null, userManager.Object, roleManager.Object);

            // Act
            IActionResult actionResult = await controller.ManageRoles(FirstUserId);

            // Arrange
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<IdentityRoleViewModel>();

            IdentityRoleViewModel returnedModel = model.As<IdentityRoleViewModel>();
            returnedModel.Username.Should().Be(FirstUserUsername);
        }

        [Fact]
        public async Task ManageRolesPost_ShouldReturnNotFoundWhenInvalidUserId()
        {
            // Arrange
            Mock<UserManager<User>> userManager = UserManagerMock.GetNew();
            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.ManageRoles(InvalidUserId, new IdentityRoleViewModel());

            // Assert
            actionResult.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task ManageRolesPost_ShouldReturnViewWithCorrectModelWhenModelStateIsInvalid()
        {
            // Arrange
            Mock<RoleManager<IdentityRole>> roleManager = GetAndSetRoleManagerMock();

            Mock<UserManager<User>> userManager = GetAndSetUserManagerMock();

            HomeController controller = new HomeController(null, userManager.Object, roleManager.Object);
            controller.ModelState.AddModelError(string.Empty, "Error");

            // Act
            IActionResult actionResult = await controller.ManageRoles(FirstUserId, new IdentityRoleViewModel());

            // Assert
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<IdentityRoleViewModel>();
        }

        [Fact]
        public async Task ManageRolesPost_ShouldReturnViewWithModelWhenRemoveFromRolesAsyncFailed()
        {
            // Arrange
            IdentityRoleViewModel formModel = new IdentityRoleViewModel()
            {
                Username = FirstUserUsername
            };

            Mock<RoleManager<IdentityRole>> roleManager = this.GetAndSetRoleManagerMock();

            Mock<UserManager<User>> userManager = this.GetAndSetUserManagerMock();
            userManager
                .Setup(um => um.RemoveFromRolesAsync(It.IsAny<User>(), It.IsAny<List<string>>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "test" }));

            HomeController controller = new HomeController(null, userManager.Object, roleManager.Object);

            // Act
            IActionResult actionResult = await controller.ManageRoles(FirstUserId, formModel);

            // Assert
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<IdentityRoleViewModel>();

            IdentityRoleViewModel returnedModel = model.As<IdentityRoleViewModel>();
            returnedModel.Username.Should().Be(formModel.Username);
        }

        [Fact]
        public async Task ManageRolesPost_ShouldReturnViewWithModelWhenAddToRolesAsyncFailed()
        {
            // Arrange
            IdentityRoleViewModel formModel = new IdentityRoleViewModel()
            {
                Username = FirstUserUsername
            };

            Mock<RoleManager<IdentityRole>> roleManager = this.GetAndSetRoleManagerMock();

            Mock<UserManager<User>> userManager = this.GetAndSetUserManagerMock();
            userManager
                .Setup(um => um.RemoveFromRolesAsync(It.IsAny<User>(), It.IsAny<List<string>>()))
                .ReturnsAsync(IdentityResult.Success);

            userManager
                .Setup(um => um.AddToRolesAsync(It.IsAny<User>(), It.IsAny<List<string>>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "test" }));

            HomeController controller = new HomeController(null, userManager.Object, roleManager.Object);

            // Act
            IActionResult actionResult = await controller.ManageRoles(FirstUserId, formModel);

            // Assert
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<IdentityRoleViewModel>();

            IdentityRoleViewModel returnedModel = model.As<IdentityRoleViewModel>();
            returnedModel.Username.Should().Be(formModel.Username);
        }

        [Fact]
        public async Task ManageRolesPost_ShouldReturnRedirectToActionWhenValidUserId()
        {
            // Arrange
            string tempDataSuccessMessage = null;

            IdentityRoleViewModel formModel = new IdentityRoleViewModel()
            {
                SelectedRoles = new List<string>() { WebConstants.AdministratorRole },
                Username = FirstUserUsername
            };

            Mock<RoleManager<IdentityRole>> roleManager = this.GetAndSetRoleManagerMock();

            Mock<UserManager<User>> userManager = this.GetAndSetUserManagerMock();
            userManager
                .Setup(um => um.RemoveFromRolesAsync(It.IsAny<User>(), It.IsAny<List<string>>()))
                .ReturnsAsync(IdentityResult.Success);

            userManager
                .Setup(um => um.AddToRolesAsync(It.IsAny<User>(), It.IsAny<List<string>>()))
                .ReturnsAsync(IdentityResult.Success);

            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();
            tempData.SetupSet(t => t["SuccessMessage"] = It.IsAny<string>())
                .Callback((string key, object successMessage) => tempDataSuccessMessage = successMessage as string);

            HomeController controller = new HomeController(null, userManager.Object, roleManager.Object);
            controller.TempData = tempData.Object;

            // Act
            IActionResult actionResult = await controller.ManageRoles(FirstUserId, formModel);

            // Assert
            actionResult.Should().BeOfType<RedirectToActionResult>();
            actionResult.As<RedirectToActionResult>().ActionName.Should().Be("AllUsers");

            tempDataSuccessMessage.Should().Be(ManageRolesMessageSuccessfull);
        }


        #endregion

        #region Rset Password

        [Fact]
        public async Task ResetPasswordGet_ShouldReturnNotFoundWhenInvalidUserId()
        {
            // Arrange
            Mock<UserManager<User>> userManager = UserManagerMock.GetNew();

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.ResetPassword(InvalidUserId);

            // Assert
            actionResult.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task ResetPasswordGet_ShouldReturnViewWithCorrectModelWhenValidUserId()
        {
            // Arrange
            Mock<UserManager<User>> userManager = this.GetAndSetUserManagerMock();

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.ResetPassword(FirstUserId);

            // Arrange
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<IdentityResetPasswordVewModel>();

            IdentityResetPasswordVewModel returnedModel = model.As<IdentityResetPasswordVewModel>();
            returnedModel.Username.Should().Be(FirstUserUsername);
        }

        [Fact]
        public async Task ResetPasswordPost_ShouldReturnViewWithCorrectModelWhenModelStateIsInvalid()
        {
            // Arrange
            HomeController controller = new HomeController(null, null, null);
            controller.ModelState.AddModelError(string.Empty, "Error");

            // Act
            IActionResult actionResult = await controller.ResetPassword(FirstUserId, new IdentityResetPasswordVewModel());

            // Assert
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<IdentityResetPasswordVewModel>();
        }

        [Fact]
        public async Task ResetPasswordPost_ShouldReturnNotFoundWhenInvalidUserId()
        {
            // Arrange
            Mock<UserManager<User>> userManager = UserManagerMock.GetNew();

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.ResetPassword(InvalidUserId, new IdentityResetPasswordVewModel());

            // Assert
            actionResult.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task ResetPasswordPost_ShouldReturnViewWithModelWhenResetPasswordAsyncFailed()
        {
            // Arrange
            IdentityResetPasswordVewModel formModel = new IdentityResetPasswordVewModel()
            {
                Username = "First"
            };

            Mock<UserManager<User>> userManager = this.GetAndSetUserManagerMock();

            userManager
                .Setup(um => um.ResetPasswordAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "test" }));

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.ResetPassword(FirstUserId, formModel);

            // Assert
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<IdentityResetPasswordVewModel>();

            IdentityResetPasswordVewModel returnedModel = model.As<IdentityResetPasswordVewModel>();
            returnedModel.Username.Should().Be(formModel.Username);
        }

        [Fact]
        public async Task ResetPasswordPost_ShouldReturnRedirectToActionWhenValidUserId()
        {
            // Arrange
            string tempDataSuccessMessage = null;

            IdentityResetPasswordVewModel formModel = new IdentityResetPasswordVewModel()
            {
                Username = "First"
            };

            Mock<UserManager<User>> userManager = this.GetAndSetUserManagerMock();

            userManager
                .Setup(um => um.ResetPasswordAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();
            tempData.SetupSet(t => t["SuccessMessage"] = It.IsAny<string>())
                .Callback((string key, object successMessage) => tempDataSuccessMessage = successMessage as string);

            HomeController controller = new HomeController(null, userManager.Object, null);
            controller.TempData = tempData.Object;

            // Act
            IActionResult actionResult = await controller.ResetPassword(FirstUserId, formModel);

            // Assert
            actionResult.Should().BeOfType<RedirectToActionResult>();
            actionResult.As<RedirectToActionResult>().ActionName.Should().Be("AllUsers");

            tempDataSuccessMessage.Should().Be(ResetPasswordMessageSuccessfull);
        }

        #endregion

        #region Add User

        [Fact]
        public void AddUserGet_ShouldReturnView()
        {
            // Arrange
            HomeController controller = new HomeController(null, null, null);

            // Act
            IActionResult actionResult = controller.AddUser();

            // Assert
            actionResult.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public async Task AddUserPost_ShouldReturnViewWithCorrectModelWhenModelStateIsInvalid()
        {
            // Arrange
            HomeController controller = new HomeController(null, null, null);
            controller.ModelState.AddModelError(string.Empty, "Error");

            // Act
            IActionResult actionResult = await controller.AddUser(new RegisterViewModel());

            // Assert
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<RegisterViewModel>();
        }

        [Fact]
        public async Task AddUserPost_ShouldReturnViewWithModelWhenCreateAsyncFailed()
        {
            // Arrange
            RegisterViewModel formModel = new RegisterViewModel()
            {
                Username = "NewUsername"
            };

            Mock<UserManager<User>> userManager = UserManagerMock.GetNew();

            userManager
                .Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "test" }));

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.AddUser(formModel);

            // Assert
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<RegisterViewModel>();

            var returnedModel = model.As<RegisterViewModel>();
            returnedModel.Username.Should().Be(formModel.Username);
        }

        [Fact]
        public async Task AddUserPost_ShouldReturnRedirectToActionWhenModelStateIsValid()
        {
            // Arrange
            string tempDataSuccessMessage = null;

            RegisterViewModel formModel = new RegisterViewModel()
            {
                Email = FirstUserEmail,
                Username = FirstUserUsername,
            };

            Mock<UserManager<User>> userManager = UserManagerMock.GetNew();
            userManager
                .Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();
            tempData.SetupSet(t => t["SuccessMessage"] = It.IsAny<string>())
                .Callback((string key, object successMessage) => tempDataSuccessMessage = successMessage as string);

            HomeController controller = new HomeController(null, userManager.Object, null);
            controller.TempData = tempData.Object;

            // Act
            IActionResult actionResult = await controller.AddUser(formModel);

            // Assert
            actionResult.Should().BeOfType<RedirectToActionResult>();
            actionResult.As<RedirectToActionResult>().ActionName.Should().Be("AllUsers");

            tempDataSuccessMessage.Should().Be(AddUserMessageSuccessfull);
        }

        #endregion

        #region EditUser

        [Fact]
        public async Task EditUsersGet_ShouldReturnNotFoundWhenInvalidUserId()
        {
            // Arrange
            Mock<UserManager<User>> userManager = UserManagerMock.GetNew();

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.EditUser(InvalidUserId);

            // Assert
            actionResult.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task EditUserGet_ShouldReturnViewWithCorrectModelWhenValidUserId()
        {
            // Arrange
            Mock<UserManager<User>> userManager = this.GetAndSetUserManagerMock();

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.EditUser(FirstUserId);

            // Arrange
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<IdentityRegisterViewModel>();

            IdentityRegisterViewModel returnedModel = model.As<IdentityRegisterViewModel>();
            returnedModel.Email.Should().Be(FirstUserEmail);
            returnedModel.Username.Should().Be(FirstUserUsername);
        }

        [Fact]
        public async Task EditUserPost_ShouldReturnViewWithCorrectModelWhenModelStateIsInvalid()
        {
            // Arrange
            HomeController controller = new HomeController(null, null, null);
            controller.ModelState.AddModelError(string.Empty, "Error");

            // Act
            IActionResult actionResult = await controller.EditUser(FirstUserId, new IdentityRegisterViewModel());

            // Assert
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<IdentityRegisterViewModel>();
        }

        [Fact]
        public async Task EditUserPost_ShouldReturnNotFoundWhenInvalidUserId()
        {
            // Arrange
            Mock<UserManager<User>> userManager = UserManagerMock.GetNew();

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.EditUser(InvalidUserId, new IdentityRegisterViewModel());

            // Assert
            actionResult.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task EditUserPost_ShouldReturnViewWithModelWhenUpdateAsyncFailed()
        {
            // Arrange
            IdentityRegisterViewModel formModel = new IdentityRegisterViewModel()
            {
                Email = "NewEmail",
                Username = "NewUsername"
            };

            Mock<UserManager<User>> userManager = this.GetAndSetUserManagerMock();

            userManager
                .Setup(um => um.UpdateAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "test" }));

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.EditUser(FirstUserId, formModel);

            // Assert
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<IdentityRegisterViewModel>();

            IdentityRegisterViewModel returnedModel = model.As<IdentityRegisterViewModel>();
            returnedModel.Email.Should().Be(formModel.Email);
            returnedModel.Username.Should().Be(formModel.Username);
        }

        [Fact]
        public async Task EditUserPost_ShouldReturnRedirectToActionWhenValidUserId()
        {
            // Arrange
            string tempDataSuccessMessage = null;

            IdentityRegisterViewModel formModel = new IdentityRegisterViewModel()
            {
                Email = "NewEmail",
                Username = "First"
            };

            Mock<UserManager<User>> userManager = this.GetAndSetUserManagerMock();

            userManager
                .Setup(um => um.UpdateAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);

            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();
            tempData.SetupSet(t => t["SuccessMessage"] = It.IsAny<string>())
                .Callback((string key, object successMessage) => tempDataSuccessMessage = successMessage as string);

            HomeController controller = new HomeController(null, userManager.Object, null);
            controller.TempData = tempData.Object;

            // Act
            IActionResult actionResult = await controller.EditUser(FirstUserId, formModel);

            // Assert
            actionResult.Should().BeOfType<RedirectToActionResult>();
            actionResult.As<RedirectToActionResult>().ActionName.Should().Be("AllUsers");

            tempDataSuccessMessage.Should().Be(EditUserMessageUpdated);
        }

        #endregion

        #region Delete User

        [Fact]
        public async Task DeleteUserGet_ShouldReturnNotFoundWhenInvalidUserId()
        {
            // Arrange
            Mock<UserManager<User>> userManager = UserManagerMock.GetNew();

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.DeleteUser(InvalidUserId);

            // Assert
            actionResult.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task DeleteUserGet_ShouldReturnViewWithCorrectModelWhenValidUserId()
        {
            // Arrange
            Mock<UserManager<User>> userManager = this.GetAndSetUserManagerMock();

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.DeleteUser(FirstUserId);

            // Arrange
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<IdentityDeleteUserViewModel>();

            IdentityDeleteUserViewModel returnedModel = model.As<IdentityDeleteUserViewModel>();
            returnedModel.Username.Should().Be(FirstUserUsername);
        }

        [Fact]
        public async Task DeleteUserPost_ShouldReturnNotFoundWhenInvalidUserId()
        {
            // Arrange
            Mock<UserManager<User>> userManager = UserManagerMock.GetNew();

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.DeleteUser(InvalidUserId);

            // Assert
            actionResult.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task DeleteUserPost_ShouldReturnViewWithModelWhenDeleteAsyncFailed()
        {
            // Arrange
            IdentityDeleteUserViewModel formModel = new IdentityDeleteUserViewModel()
            {
                Username = "First"
            };

            Mock<UserManager<User>> userManager = this.GetAndSetUserManagerMock();

            userManager
                .Setup(um => um.DeleteAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "test" }));

            HomeController controller = new HomeController(null, userManager.Object, null);

            // Act
            IActionResult actionResult = await controller.DeleteUser(FirstUserId);

            // Assert
            actionResult.Should().BeOfType<ViewResult>();

            object model = actionResult.As<ViewResult>().Model;
            model.Should().BeOfType<IdentityDeleteUserViewModel>();

            var returnedModel = model.As<IdentityDeleteUserViewModel>();
            returnedModel.Username.Should().Be(formModel.Username);
        }

        [Fact]
        public async Task DeleteUserPost_ShouldReturnRedirectToActionWhenValidUserId()
        {
            // Arrange
            string tempDataSuccessMessage = null;

            Mock<UserManager<User>> userManager = this.GetAndSetUserManagerMock();

            userManager
                .Setup(um => um.DeleteAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);

            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();
            tempData.SetupSet(t => t["SuccessMessage"] = It.IsAny<string>())
                .Callback((string key, object successMessage) => tempDataSuccessMessage = successMessage as string);

            HomeController controller = new HomeController(null, userManager.Object, null);
            controller.TempData = tempData.Object;

            // Act
            IActionResult actionResult = await controller.DestroyUser(FirstUserId);

            // Assert
            actionResult.Should().BeOfType<RedirectToActionResult>();
            actionResult.As<RedirectToActionResult>().ActionName.Should().Be("AllUsers");

            tempDataSuccessMessage.Should().Be(DeleteMessageSuccessfull);
        }

        #endregion

        #region Private Methods

        private Mock<RoleManager<IdentityRole>> GetAndSetRoleManagerMock()
        {
            Mock<RoleManager<IdentityRole>> roleManager = RoleManagerMock.GetNew();

            var roles = new List<IdentityRole>()
            {
                new IdentityRole(WebConstants.AdministratorRole)
            };

            Mock<DbSet<IdentityRole>> mockAsync = roles.ToDbSetAsyncMock();

            roleManager
                .Setup(rm => rm.Roles)
                .Returns(mockAsync.Object);

            return roleManager;
        }

        private Mock<UserManager<User>> GetAndSetUserManagerMock()
        {
            Mock<UserManager<User>> userManager = UserManagerMock.GetNew();

            User user = this.GetUser();

            userManager
                .Setup(um => um.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            userManager
                .Setup(um => um.GetRolesAsync(user))
                .ReturnsAsync(new List<string>() { WebConstants.AdministratorRole });

            return userManager;
        }

        private User GetUser()
        {
            return new User()
            {
                Id = FirstUserId,
                Email = FirstUserEmail,
                UserName = FirstUserUsername
            };
        }

        #endregion
    }
}
