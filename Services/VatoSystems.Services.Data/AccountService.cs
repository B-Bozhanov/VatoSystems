namespace VatoSystems.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;

    using VatoSystems.Data.Models;
    using VatoSystems.Services.Data.Interfaces;
    using VatoSystems.Web.ViewModels.Account;

    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<RegisterModel> logger;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        public async Task<SignInResult> LoginAsync(LoginModel loginModel)
        {
            if (!IsValid(loginModel))
            {
                throw new InvalidOperationException("Invalid model!");
            }

            loginModel.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            var result = await this.signInManager
                .PasswordSignInAsync(
                loginModel.UserName,
                loginModel.Password,
                loginModel.RememberMe,
                lockoutOnFailure: false);

            return result;
        }

        public async Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterAsync(RegisterModel registerModel)
        {
            if (!IsValid(registerModel))
            {
                throw new InvalidOperationException("Invalid model");
            }

            var user = CreateUser(registerModel);

            var result = await this.userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                this.logger.LogInformation($"User created a new account with password at {DateTime.UtcNow}.");
                await this.signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }

        private static bool IsValid(object obj)
            => Validator.TryValidateObject(
                obj,
                new ValidationContext(obj), 
                new List<ValidationResult>(),
                true);

        private static ApplicationUser CreateUser(RegisterModel registerModel)
        {
            var user = new ApplicationUser
            {
                UserName = registerModel.Username,
                Email = registerModel.Email,
            };

            return user;
        }
    }
}
