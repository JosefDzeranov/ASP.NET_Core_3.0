using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
using System;
using OnlineShop.DB.Services;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index(Guid id)
        {

            var product = productRepository.TryGetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var productViewModel = product.MappingToProductViewModel();
            return View(productViewModel);
        }
    }
}
