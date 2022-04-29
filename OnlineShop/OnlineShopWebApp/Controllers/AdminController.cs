using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        /// 123123123
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  2
        /// </summary>
        /// <returns></returns>
        public IActionResult Status()
        {
            return View();
        }
    }
}
