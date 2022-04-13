using Microsoft.AspNetCore.Mvc;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class PersonController : Controller
    {

        public IActionResult Index()
        {
            return View ();
        }
    }
}
