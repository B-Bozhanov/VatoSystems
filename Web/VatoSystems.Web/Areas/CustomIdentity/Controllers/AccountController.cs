namespace VatoSystems.Web.Areas.Identity.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using VatoSystems.Data.Models;
    using VatoSystems.Services.Data.Interfaces;
    using VatoSystems.Web.Controllers;
    using VatoSystems.Web.ViewModels.Account;

    [Area("CustomIdentity")]
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<RegisterModel> logger;
        private readonly IAccountService accountService;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IAccountService accountService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.accountService = accountService;
        }

        public Task<IActionResult> ForgotPassword()
        {
            return null;
        }

        [AllowAnonymous]
        [Route("/Account/Login")]
        [HttpGet("/Account/Login")]
        public async Task<IActionResult> LoginAsync(string returnUrl = null)
        {
            returnUrl ??= this.Url.Content("~/");
            await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return this.View(new LoginModel
            {
                ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
                ReturnUrl = returnUrl,
            });
        }

        [AllowAnonymous]
        [Route("/Account/Login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel loginModel, string returnUrl = null)
        {
            returnUrl ??= this.Url.Content("~/");

            if (this.ModelState.IsValid)
            {
                try
                {
                    var result = await this.accountService.LoginAsync(loginModel);

                    if (result.Succeeded)
                    {
                        this.logger.LogInformation("User logged in.");
                        return this.LocalRedirect(returnUrl);
                    }

                    if (result.RequiresTwoFactor)
                    {
                        return this.RedirectToAction(nameof(this.LoginWith2faAsync), new { ReturnUrl = returnUrl, RememberMe = loginModel.RememberMe });
                    }

                    if (result.IsLockedOut)
                    {
                        this.logger.LogWarning("User account locked out.");
                        return this.RedirectToAction(nameof(this.LockoutAsync));
                    }
                    else
                    {
                        this.ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return this.View(loginModel);
                    }
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            // If we got this far, something failed, redisplay form
            return this.View(loginModel);
        }

        public async Task<IActionResult> LoginWith2faAsync()
        {
            return null;
        }

        public async Task<IActionResult> LockoutAsync()
        {
            return null;
        }

        [AllowAnonymous]
        [Route("/Account/Register")]
        [HttpGet]
        public async Task<IActionResult> RegisterAsync(string returnUrl = null)
            => this.View(new RegisterModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
            });

        [AllowAnonymous]
        [Route("/Account/Register")]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterModel registerModel, string returnUrl)
        {
            returnUrl ??= this.Url.Content("~/");

            if (this.ModelState.IsValid)
            {
                try
                {
                    var result = await this.accountService.RegisterAsync(registerModel);

                    if (result.Succeeded)
                    {
                        return this.LocalRedirect(returnUrl);
                    }

                    foreach (var error in result.Errors)
                    {
                        this.ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError(string.Empty, ex.Message);
                    return this.View(registerModel);
                }
            }

            return this.View(registerModel);
        }

        public async Task<IActionResult> Logout()
        {
            throw new Exception();
        }
    }
}
