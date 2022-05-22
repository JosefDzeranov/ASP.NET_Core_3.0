using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller


    {
        private readonly IProductsRepository productsRepository;
        private readonly IComparesRepository comparesRepository;

        public CompareController(IProductsRepository productsRepository, IComparesRepository comparesRepository)
        {
            this.productsRepository = productsRepository;
            this.comparesRepository = comparesRepository;
        }
        public IActionResult Index()
        {            
            var products = comparesRepository.GetCompare(Constants.UserId);
            return View(Mapping.ToProductViewModels(products));
        }
        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            comparesRepository.Add(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            comparesRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid productId)
        {
            comparesRepository.Delete(Constants.UserId, productId);
            return RedirectToAction("Index");
        }
    }
}
