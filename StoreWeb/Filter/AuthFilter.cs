
using System.Web.Mvc;
using System.Web.Security;

namespace StoreWeb
{
    public class AuthFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            bool isAnoy = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            var identity = filterContext.HttpContext.User.Identity;
            if (!isAnoy && identity.IsAuthenticated)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    var result = new
                    {
                        flag = false,
                        data = string.Empty,
                        msg = "请登录"
                    };
                    filterContext.Result = new JsonResult
                    {
                        Data = result,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }
    }
}