using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Products()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            var productDb = new ProductViewModel
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                Pages = product.Pages
            };

            if (ModelState.IsValid)
            {
                productsRepository.Add(productDb);
                return RedirectToAction("Products");
            }
            else
            {
                return View(product);
            }
        }
        public IActionResult Edit(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            var productDb = new ProductViewModel
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                Pages = product.Pages
            };

            if (ModelState.IsValid)
            {
                productsRepository.Edit(productDb);
                return RedirectToAction("Products");
            }
            else
            {
                return View(product);
            }
        }
        public IActionResult Delete(Guid productId)
        {
            productsRepository.Delete(productId);
            return RedirectToAction("Products");
        }
    }
}
