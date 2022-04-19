using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductCatalog productCatalog;
        private readonly PersonCatalog personCatalog;
        public CartController(PersonCatalog personCatalog, ProductCatalog productCatalog)
        {
            this.personCatalog = personCatalog;
            this.productCatalog = productCatalog;
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
