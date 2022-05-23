using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class ComparisonController : Controller
    {
        private readonly IProductManager productManager;
        private readonly IComparison comparisonManager;
        List<ProductViewModel> compareList = new List<ProductViewModel>();

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


        public IActionResult AddToCompare(Guid id)
        {
            var foundProduct = productManager.TryGetById(id);

            var productView = new ProductViewModel
            {
                Name = foundProduct.Name,
                Cost = foundProduct.Cost,
                Description = foundProduct.Description,
            };


            if (comparisonManager.Products.FirstOrDefault(x => x.Id == id) == null)
            {
                comparisonManager.AddProduct(productView);
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
