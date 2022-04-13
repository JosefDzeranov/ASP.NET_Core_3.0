using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;

namespace OnlineDesignBureauWebApp.Controllers
{

    public class PersonController : Controller
    {
        public IActionResult Index(int id)
        {
            return View(PersonCatalog.FindPerson(id));
        }
        public IActionResult Basket(int id)
        {
            return View(PersonCatalog.FindPerson(id));
        }
        public IActionResult AddProductInBasket(int id_product, int id_person)
        {
            PersonCatalog.AddProductInBaset(id_product, id_person);
            PersonCatalog.WriteToJson();
            return View ("Basket", PersonCatalog.FindPerson(id_person));
        }
        public IActionResult DeleteProductInBasket(int id_product, int id_person)
        {
            PersonCatalog.DeleteProductInBaset(id_product, id_person);
            PersonCatalog.WriteToJson();
            return View ("Basket", PersonCatalog.FindPerson(id_person));
        }
        public IActionResult Comparison(int id)
        {
            return View(PersonCatalog.FindPerson(id));
        }
        public IActionResult Orders(int id)
        {
            return View(PersonCatalog.FindPerson(id));
        }

    }
}
