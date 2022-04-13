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
        public IActionResult Basket(int id_product, int id_person = 0)
        {
            PersonCatalog.FindPerson(id_person).BasketList.Add(ProductCatalog.FindProduct(id_product));
            PersonCatalog.WriteToJson();
            return View(PersonCatalog.FindPerson(id_person));
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
