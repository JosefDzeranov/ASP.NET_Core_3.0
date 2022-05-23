using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager productManager;

        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public IActionResult Index(Guid id)
        {
            var foundProduct = productManager.TryGetById(id);

            var productView = new ProductViewModel
            {
                Name = foundProduct.Name,
                Cost = foundProduct.Cost,
                Description = foundProduct.Description,
            };
            return View(foundProduct);
        }

    }

}
