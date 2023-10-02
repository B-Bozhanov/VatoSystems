namespace VatoSystems.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using VatoSystems.Web.ViewModels.Account;

    public interface IAccountService
    {
        public Task<IdentityResult> RegisterAsync(RegisterModel registerModel);

        public Task<SignInResult> LoginAsync(LoginModel inputModel);

        public Task LogoutAsync();
    }
}
