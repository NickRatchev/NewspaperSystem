namespace NewspaperSystem.Web.Areas.Identity.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models;
    using NewspaperSystem.Services.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.Models.AccountViewModels;

    [Area(WebConstants.IdentityArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class HomeController : Controller
    {
        private readonly IIdentityService users;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(
            IIdentityService users,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.users = users;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> AllUsers()
        {
            return View(await this.users.AllUsersAsync());
        }

        public async Task<IActionResult> ManageRoles(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            IdentityRoleViewModel viewModel = await GetRoleViewModel(user);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ManageRoles(string id, IdentityRoleViewModel model)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(await GetRoleViewModel(user));
            }

            var currentRoles = await this.userManager.GetRolesAsync(user);

            var result = await this.userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!result.Succeeded)
            {
                AddErrors(result);

                return View(model);
            }

            result = await this.userManager.AddToRolesAsync(user, model.SelectedRoles);

            if (!result.Succeeded)
            {
                AddErrors(result);

                return View(model);
            }

            this.TempData["SuccessMessage"] = $"Successfuly changed roles for user \"{user.UserName}\"!";
            return RedirectToAction(nameof(AllUsers));
        }

        public IActionResult AddUser() => View();

        [HttpPost]
        public async Task<IActionResult> AddUser(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await this.userManager.CreateAsync(new User()
            {
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            }, model.Password);

            if (!result.Succeeded)
            {
                AddErrors(result);

                return View(model);
            }

            this.TempData["SuccessMessage"] = $"User \"{model.Username}\" was successfuly created!";

            return RedirectToAction(nameof(AllUsers));
        }

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(new IdentityRegisterViewModel
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, IdentityRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.Username;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            var result = await this.userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                AddErrors(result);

                return View(model);
            }

            this.TempData["SuccessMessage"] = $"User \"{model.Username}\" was updated successfuly!";

            return RedirectToAction(nameof(AllUsers));
        }

        public async Task<IActionResult> ResetPassword(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(new IdentityResetPasswordVewModel
            {
                Username = user.UserName
            });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string id, IdentityResetPasswordVewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var token = await this.userManager.GeneratePasswordResetTokenAsync(user);
            var result = await this.userManager.ResetPasswordAsync(user, token, model.Password);

            if (!result.Succeeded)
            {
                AddErrors(result);

                return View(model);
            }

            this.TempData["SuccessMessage"] = $"Password for user \"{user.UserName}\" was successfuly changed!";

            return RedirectToAction(nameof(AllUsers));
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(new IdentityDeleteUserViewModel()
            {
                Id = user.Id,
                Username = user.UserName
            });
        }

        public async Task<IActionResult> DestroyUser(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            this.TempData["SuccessMessage"] = $"User \"{user.UserName}\" was successfuly deleted!";

            var result = await this.userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                AddErrors(result);

                return View(id);
            }

            return RedirectToAction(nameof(AllUsers));
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private async Task<IdentityRoleViewModel> GetRoleViewModel(User user)
        {
            var currentRoles = await this.userManager.GetRolesAsync(user);

            var viewModel = new IdentityRoleViewModel
            {
                Username = user.UserName,
                SelectedRoles = currentRoles,
                AvailableRoles = this.roleManager
                    .Roles
                    .ToList()
                    .Select(r => new SelectListItem()
                    {
                        Text = r.Name.Replace("User", " User"),
                        Value = r.Name
                    }).ToList()
            };

            return viewModel;
        }
    }
}
