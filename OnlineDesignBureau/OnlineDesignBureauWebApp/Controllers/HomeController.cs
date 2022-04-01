using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineDesignBureauWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductCatalog productCatalog;
        public HomeController()
        {
            productCatalog = new ProductCatalog();
        }
        public string Index()
        {
            if (productCatalog.GetProducts().Count==0)
                productCatalog.ReadToJson("projects_for_sale");
            var result = "";
            foreach (var product in productCatalog.GetProducts())
            {
                result += product + "\n\n";
            }
            return result;
        }
    }
}
