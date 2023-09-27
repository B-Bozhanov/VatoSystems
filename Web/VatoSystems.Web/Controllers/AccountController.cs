namespace VatoSystems.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using VatoSystems.Services.Data.Interfaces;
    using VatoSystems.Web.ViewModels.Account;

    public class AccountController : BaseController
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
            => this.View(new LoginModel());

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    await this.accountService.LoginAsync(inputModel);
                    return this.RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return this.View(inputModel);
        }
    }
}
