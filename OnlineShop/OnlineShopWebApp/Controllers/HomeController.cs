using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
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
            var products = _productManager.GetAll();
            return View(Mapping.ToProductsViewModels(products));
        }

        [HttpPost]
        public IActionResult SearchByName(string name)
        {

            // var productByPartName = new List<ProductViewModel>();
            if (name != null)
            {
                var productByPartName = _productManager.GetAll().FirstOrDefault(x => x.Name.ToLower().Contains(name.ToLower()));

                var productView = new ProductViewModel
                {
                    Name = productByPartName.Name,
                    Cost = productByPartName.Cost,
                    Description = productByPartName.Description,

                };
                return View(productView);

            }
            else
            {
                return RedirectToAction("Index");
            }


        }


    }
}
