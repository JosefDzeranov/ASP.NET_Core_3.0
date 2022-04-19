using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;

namespace OnlineDesignBureauWebApp.Controllers
{

    public class PersonController : Controller
    {
        private readonly PersonCatalog personCatalog;

        public PersonController(PersonCatalog personCatalog)
        {
            this.personCatalog = personCatalog;
        }
        public IActionResult Index(int personId)
        {
            return View(personCatalog.FindPerson(personId));
        }

    }
}
