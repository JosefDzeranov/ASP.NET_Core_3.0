using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;
using OnlineShop.Db;
using Microsoft.AspNetCore.Authorization;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{    
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index(Guid Id)
        {
            var product = productsRepository.TryGetById(Id);
            return View(Mapping.ToProductViewModel(product));
        }
        
    }
}
