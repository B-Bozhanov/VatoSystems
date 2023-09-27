namespace VatoSystems.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    using VatoSystems.Web.ViewModels.Account;

    public interface IAccountService
    {
        public Task RegisterAsync(RegisterModel registerModel, string returnUrl);

        public Task LoginAsync(LoginModel inputModel);

        public Task LogoutAsync();
    }
}
