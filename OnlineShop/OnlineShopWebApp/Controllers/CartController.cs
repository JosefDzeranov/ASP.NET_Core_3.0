using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;

namespace OnlineDesignBureauWebApp.Controllers
{

    public class CartController : Controller
    {
        public IActionResult Index(int personId)
        {
            return View(PersonCatalog.FindPerson(personId));
        }

        public IActionResult AddProductInCart(int productId, int personId)
        {
            PersonCatalog.AddProductInBaset(productId, personId);
            PersonCatalog.WriteToJson();
            return RedirectToAction("Index",personId);
        }
        public IActionResult DeleteProductInBasket(int productId, int personId)
        {
            PersonCatalog.DeleteProductInBaset(productId, personId);
            PersonCatalog.WriteToJson();
            return RedirectToAction("Index", personId);
        }


    }
}
