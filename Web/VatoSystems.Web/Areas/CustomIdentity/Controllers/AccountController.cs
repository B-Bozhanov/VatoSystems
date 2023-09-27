namespace VatoSystems.Web.Areas.Identity.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Extensions.Logging;

    using VatoSystems.Data.Models;
    using VatoSystems.Web.Controllers;
    using VatoSystems.Web.ViewModels.Account;

    [Area("CustomIdentity")]
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserStore<ApplicationUser> userStore;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<RegisterModel> logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            this.userManager = userManager;
            this.userStore = userStore;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            throw new Exception();
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
            registerModel.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (this.ModelState.IsValid)
            {
                var user = this.CreateUser();

                await this.userStore.SetUserNameAsync(user, registerModel.Email, CancellationToken.None);
                var result = await this.userManager.CreateAsync(user, registerModel.Password);

                if (result.Succeeded)
                {
                    this.logger.LogInformation("User created a new account with password.");

                    var userId = await this.userManager.GetUserIdAsync(user);
                    var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = this.Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: this.Request.Scheme);

                    if (this.userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return this.RedirectToPage("RegisterConfirmation", new { email = registerModel.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await this.signInManager.SignInAsync(user, isPersistent: false);
                        return this.(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return this.View(registerModel);
        }

        public async Task<IActionResult> Logout()
        {
            throw new Exception();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!this.userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }

            return (IUserEmailStore<ApplicationUser>)this.userStore;
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await this.userManager.GetUserNameAsync(user);
            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);

            //Username = userName;

            //Input = new InputModel
            //{
            //    PhoneNumber = phoneNumber
            //};
        }
    }
}
