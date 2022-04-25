using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Views.Shared.Components.AdminPanel
{
    public class AdminPanel : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Menu");
        }
    }
}