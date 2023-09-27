using System.Web.Http;

namespace VatoSystems.Web.Infrastructure.Attributes
{

    public class CustomAuthorize : AuthorizeAttribute
    {
        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    base.OnAuthorization(filterContext);
        //    if (filterContext.Result is HttpUnauthorizedResult)
        //    {
        //        filterContext.Result = new RedirectToRouteResult(
        //            new System.Web.Routing.RouteValueDictionary
        //                {
        //                        { "langCode", filterContext.RouteData.Values[ "langCode" ] },
        //                        { "controller", "Account" },
        //                        { "action", "Login" },
        //                        { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
        //                });
        //    }
        //}
    }
}
