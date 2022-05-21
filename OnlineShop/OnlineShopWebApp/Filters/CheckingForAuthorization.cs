

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Filters
{
    public class CheckingForAuthorization : ActionFilterAttribute
    {
        private readonly IUserManager userManager;
        public CheckingForAuthorization(IUserManager userManager)
        {
            this.userManager = userManager;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!userManager.CheckingForAuthorization())
            {
                context.Result =
                    new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        Area = "",
                        controller = "Login",
                        action = "Index"
                    }));
            }
            //else if (!userManager.GettingAccess(userManager.GetLoginAuthorizedUser(), "Index", "Cart", ""))
            //{
            //    context.Result =
            //        new RedirectToRouteResult(new RouteValueDictionary(new
            //        {
            //            controller = "Login",
            //            action = "TabooAccess"
            //        }));
            //}
            base.OnActionExecuting(context);
        }

    }
}
