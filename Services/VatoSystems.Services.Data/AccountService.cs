namespace VatoSystems.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using VatoSystems.Services.Data.Interfaces;
    using VatoSystems.Web.ViewModels.Account;

    public class AccountService : IAccountService
    {
        public Task LoginAsync(LoginModel inputModel)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(RegisterModel registerModel, string returnUrl)
        {
            throw new NotImplementedException();
        }
    }
}
