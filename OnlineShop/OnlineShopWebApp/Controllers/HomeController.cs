using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        IProductManager _productManager;


        public HomeController(IProductManager productManager)
        {
            _productManager = productManager;

        }
        public IActionResult Index()
        {

            var products = _productManager. ProductList;


            return View(products);
        }

        [HttpPost]
        public IActionResult SearchByName(string name)
        {

            var productByPartName = new List<Product>(); 
            if (name != null)
            {
                productByPartName = _productManager.ProductList.FindAll(x => x.Name.ToLower().Contains(name.ToLower()));
                return View(productByPartName);

            }
            else
            {
                return RedirectToAction("Index");
            }
           

        }

    }
}

