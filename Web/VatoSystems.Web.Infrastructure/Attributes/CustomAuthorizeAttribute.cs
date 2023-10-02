namespace VatoSystems.Web.Infrastructure.Attributes
{
    using System.Web.Http;
    using System.Web.Http.Controllers;

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
        }
    }
}
