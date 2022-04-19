using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{

    public class PersonController : Controller
    {
        private readonly IPersonStorage personCatalog;
        public PersonController(IPersonStorage personCatalog)
        {
            this.personCatalog = personCatalog;
        }
        public IActionResult Index(int personId)
        {
            return View(personCatalog.FindPerson(personId));
        }

    }
}
