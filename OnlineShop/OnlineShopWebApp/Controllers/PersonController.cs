using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;

namespace OnlineDesignBureauWebApp.Controllers
{

    public class PersonController : Controller
    {
        private readonly PersonCatalog personCatalog;
        private readonly ProductCatalog productCatalog;
        public PersonController(ProductCatalog productCatalog, PersonCatalog personCatalog)
        {
            this.productCatalog = productCatalog;
            this.personCatalog = personCatalog;
        }
        public IActionResult Index(int personId)
        {
            return View(personCatalog.FindPerson(personId));
        }

    }
}
