using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IPersonMemoryStorage personCatalog;
        private readonly IProductMemoryStorage productCatalog;
        public CartController(IPersonMemoryStorage personCatalog, IProductMemoryStorage productCatalog)
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
            personCatalog.AddProductInCart(productId, personId, productCatalog);
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
