using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;

namespace OnlineDesignBureauWebApp.Controllers
{

    public class PersonController : Controller
    {
        public IActionResult Index(int personId)
        {
            return View(PersonCatalog.FindPerson(personId));
        }

    }
}
