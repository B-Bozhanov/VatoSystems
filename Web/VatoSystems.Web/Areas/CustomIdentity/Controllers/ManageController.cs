namespace VatoSystems.Web.Areas.Identity.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using VatoSystems.Web.Controllers;

    public class ManageController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> Email()
        {
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> Password()
        {
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> TwoFactorAuthentication()
        {
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> PersonalData()
        {
            return null;
        }
    }
}
