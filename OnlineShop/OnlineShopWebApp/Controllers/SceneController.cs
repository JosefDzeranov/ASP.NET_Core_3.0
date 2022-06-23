using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class SceneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
