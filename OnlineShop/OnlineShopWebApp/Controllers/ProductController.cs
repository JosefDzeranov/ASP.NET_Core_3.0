using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager productManager;
        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public IActionResult Index(Guid productId)
        {

            var product = productManager.Find(productId);
            var productViewModels = new ProductViewModel
            {
                Id = product.Id,
                CodeNumber = product.CodeNumber,
                Cost = product.Cost,
                Description = product.Description,
                Images = product.Images,
                Length = product.Length,
                Square = product.Square,
                Width = product.Width
            };
            return View(productViewModels);
        }
    }
}
