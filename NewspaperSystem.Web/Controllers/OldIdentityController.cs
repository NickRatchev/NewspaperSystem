//namespace NewspaperSystem.Web.Controllers
//{
//    using System.Threading.Tasks;
//    using Data.Models;
//    using Microsoft.AspNetCore.Authorization;
//    using Microsoft.AspNetCore.Mvc;
//    using Models.IdentityViewModels;
//    using Microsoft.AspNetCore.Identity;
//    using Data.Models;
//    using Microsoft.AspNetCore.Authentication;
//    using Microsoft.AspNetCore.Authorization;
//    using Microsoft.AspNetCore.Identity;
//    using Microsoft.AspNetCore.Mvc;
//    using Microsoft.Extensions.Logging;
//    using NewspaperSystem.Web.Models.AccountViewModels;
//    using NewspaperSystem.Web.Services;
//    using System;
//    using System.Security.Claims;
//    using System.Threading.Tasks;

//    public class OldIdentityController : Controller
//    {
//        private readonly UserManager<User> _userManager;
//        private readonly SignInManager<User> _signInManager;
//        private readonly IEmailSender _emailSender;
//        private readonly ILogger _logger;

//        public OldIdentityController(
//            UserManager<User> userManager,
//            SignInManager<User> signInManager,
//            IEmailSender emailSender,
//            ILogger<AccountController> logger)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//            _emailSender = emailSender;
//            _logger = logger;
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(CreateUserViewModel model, string returnUrl = null)
//        {
//            ViewData["ReturnUrl"] = returnUrl;
//            if (ModelState.IsValid)
//            {
//                var user = new User
//                {
//                    UserName = model.User.Username,
//                    FirstName = model.User.FirstName,
//                    LastName = model.User.Lastname,
//                    Email = model.User.Email
//                };
//                var result = await _userManager.CreateAsync(user, model.User.Password);
//                if (result.Succeeded)
//                {
//                    _logger.LogInformation("User created a new account with password.");

//                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
//                    await _emailSender.SendEmailConfirmationAsync(model.User.Email, callbackUrl);

//                    //await _signInManager.SignInAsync(user, isPersistent: false);
//                    _logger.LogInformation("User created a new account with password.");
//                    return RedirectToLocal(returnUrl);
//                }
//                AddErrors(result);
//            }

//            // If we got this far, something failed, redisplay form
//            return View(model);
//        }

//        private void AddErrors(IdentityResult result)
//        {
//            foreach (var error in result.Errors)
//            {
//                ModelState.AddModelError(string.Empty, error.Description);
//            }
//        }

//        private IActionResult RedirectToLocal(string returnUrl)
//        {
//            if (Url.IsLocalUrl(returnUrl))
//            {
//                return Redirect(returnUrl);
//            }
//            else
//            {
//                return RedirectToAction(nameof(HomeController.Index), "Home");
//            }
//        }
//    }
//}
