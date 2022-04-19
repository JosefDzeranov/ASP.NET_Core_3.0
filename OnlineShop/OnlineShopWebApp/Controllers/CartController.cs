using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IPersonMemoryStorage personCatalog;
        public CartController(IPersonMemoryStorage personCatalog)
        {
            this.personCatalog = personCatalog;
        }
        public IActionResult Index(int personId)
        {
            return View(personCatalog.FindPerson(personId));
        }

        public IActionResult AddProductInCart(int productId, int personId)
        {
            personCatalog.AddProductInCart(productId, personId);
            personCatalog.WriteToStorage();
            return RedirectToAction("Index",personId);
        }
        public IActionResult DeleteProductInCart(int productId, int personId)
        {
            personCatalog.DeleteProductInCart(productId, personId);
            personCatalog.WriteToStorage();
            return RedirectToAction("Index", personId);
        }


    }
}
