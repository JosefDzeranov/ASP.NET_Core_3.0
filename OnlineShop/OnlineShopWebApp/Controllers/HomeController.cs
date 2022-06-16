using OnlineShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShop.DB.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            var products = await productRepository.GetAllAsync();

            var productsViewModel = products.MappingToListProductViewModel();

            return View(productsViewModel);
        }


    }
}
