namespace NewspaperSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.AccountViewModels;
    using Models.IdentityVewModels;
    using NewspaperSystem.Services.Identity;

    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class IdentityController : Controller
    {
        private readonly IIdentityService users;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<User> roleManager;

        public IdentityController(IIdentityService users, UserManager<User> userManager)
        {
            this.users = users;
            this.userManager = userManager;
            this.roleManager = this.roleManager;
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
            await this.userManager.RemoveFromRolesAsync(user, currentRoles);

            var result = await this.userManager.AddToRolesAsync(user, model.SelectedRoles);

            if (result.Succeeded)
            {
                this.TempData["SuccessMessage"] = $"Successfuly changed roles for user \"{user.UserName}\"!";
                return RedirectToAction(nameof(AllUsers));
            }

            return View(model);
        }


        public IActionResult AllUsers()
        {
            return View(this.users.AllUsers());
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
                LastName = model.Lastname,
                Email = model.Email
            }, model.Password);

            if (result.Succeeded)
            {
                this.TempData["SuccessMessage"] = $"User \"{model.Username}\" was successfuly created!";
                return RedirectToAction(nameof(AllUsers));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    AddErrors(result);
                }

                return View(model);
            }
        }

        public async Task<IActionResult> ResetPassword(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return View(new IdentityResetPasswordVewModel
                {
                    Username = user.UserName
                });
            }
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

            if (result.Succeeded)
            {
                this.TempData["SuccessMessage"] = $"Password for user \"{user.UserName}\" was successfuly changed!";
                return RedirectToAction(nameof(AllUsers));
            }
            else
            {
                AddErrors(result);

                return View(model);
            }
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
            else
            {
                this.TempData["SuccessMessage"] = $"User \"{user.UserName}\" was successfuly deleted!";
                var result = this.userManager.DeleteAsync(user);

                return RedirectToAction(nameof(AllUsers));
            }
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
                AvailableRoles = new List<SelectListItem>()
                {
                    new SelectListItem {Text = "Administrator", Value = WebConstants.AdministratorRole},
                    new SelectListItem {Text = "Regular User", Value = WebConstants.RegularUserRole},
                    new SelectListItem {Text = "Accountant", Value = WebConstants.AccountantRole},
                    new SelectListItem {Text = "Management", Value = WebConstants.ManagementRole}
                }
            };
            return viewModel;
        }
    }
}
