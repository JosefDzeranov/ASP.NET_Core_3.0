using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
using System;
using OnlineShop.DB.Services;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IActionResult> Index(Guid id)
        {

            var product = await productRepository.TryGetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var productViewModel = product.MappingToProductViewModel();
            return View(productViewModel);
        }
    }
}
