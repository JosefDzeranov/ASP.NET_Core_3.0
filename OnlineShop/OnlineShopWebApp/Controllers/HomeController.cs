using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System.Linq;
using OnlineShopWebApp.Helpers;
using System;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductStorage _productStorage;
        public HomeController(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }

        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var products = _productStorage.GetAllAvailable();
            var productViewModels = products.ToProductViewModels(currentCulture);
            return View(productViewModels);
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            if(name == null)
            {
                return RedirectToAction("Index");
            }

            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var products = _productStorage.SearchByName(name).ToList();
            var productViewModels = products.ToProductViewModels(currentCulture);
            
            if (!productViewModels.Any())
            {
                return View("NotFound");
            }

            return View(productViewModels);
        }

        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(30)
                    }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
