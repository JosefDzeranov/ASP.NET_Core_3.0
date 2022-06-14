using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index(Guid productId)
        {

            var product = _productRepository.Find(productId);
            var productViewModels = new Product_ViewModel
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
