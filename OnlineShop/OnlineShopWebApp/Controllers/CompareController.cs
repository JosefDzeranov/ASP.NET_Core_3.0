using Microsoft.AspNetCore.Mvc;
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
            var productsToCompare = comparesRepository.GetCompare();
            return View(productsToCompare);
        }
        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            comparesRepository.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            comparesRepository.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            comparesRepository.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
