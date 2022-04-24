using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class ComparisonController : Controller
    {
        private readonly IProductManager productManager;
        private readonly IComparison comparisonManager;
        List<Product> compareList = new List<Product>();

        public ComparisonController(IProductManager productManager, IComparison comparisonManager)
        {
            this.productManager = productManager;
            this.comparisonManager = comparisonManager;
            this.comparisonManager.UserId = Constants.UserId;
        }

        public IActionResult Index()
        {
            compareList = comparisonManager.Products;
            return View(compareList);

        }


        public IActionResult AddToCompare(int id)
        {
            var foundProduct = productManager.FindProduct(id);


            if (comparisonManager.Products.FirstOrDefault(x => x.Id == id) == null)
            {
                comparisonManager.AddProduct(foundProduct);
                compareList = comparisonManager.Products;
                return View(compareList);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }

}
