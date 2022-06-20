using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helper;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productReposititory;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productReposititory = productsRepository;
        }
        public IActionResult Item(Guid id)
        {
            var product = Mapping.ToProductViewModel(productReposititory.TryGetById(id));
            return View(product);
        }
        public IActionResult Items()
        {
            var products = productReposititory.GetAll();
            return View(Mapping.ToProductViewModels(products));
        }
    }
}
