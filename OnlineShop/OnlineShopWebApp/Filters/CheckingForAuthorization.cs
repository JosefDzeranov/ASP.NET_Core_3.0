using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Filters
{
    public class CheckingForAuthorization : ActionFilterAttribute
    {
        private readonly IUsersManager usersManager;
        public CheckingForAuthorization(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!usersManager.CheckingForAuthorization())
            {
                context.Result =
                    new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        Area = "",
                        controller = "Login",
                        action = "Index"
                    }));
            }

            base.OnActionExecuting(context);
        }

    }
}
