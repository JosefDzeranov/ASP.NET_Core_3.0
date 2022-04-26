using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {

        private readonly IProductsRepository productReposititory;

        public AdminController(IProductsRepository productsRepository)
        {
            this.productReposititory = productsRepository;
        }

        public IActionResult AdminPanel()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Products()
        {
            var products = productReposititory.GetAll();
            return View(products);
        }

        public IActionResult Status()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateDescription(Product product)
        {
            productReposititory.EditDescription(product);
            
            return View();
        }



        //[HttpPost]
        //public IActionResult Create(int id, Image image)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var fileName = Path.GetFileNameWithoutExtension(image.Name);
        //        var extension = Path.GetExtension(image.Name);
        //        image.Name = "item" + productReposititory.TryGetById(id) + extension;
        //        var path = Path.Combine("/Image/", fileName);
        //        var fileStream = new FileStream(path, FileMode.Create);

        //        return RedirectToAction("Index");
        //    }
        //    return View(image);
        //}

        //[HttpPost]
        //public IActionResult Delete(int id, Image image)
        //{
        //    var imagePath = Path.Combine("/Image/", image.Name);
        //    if (System.IO.File.Exists(imagePath))
        //        System.IO.File.Delete(imagePath);

        //    return RedirectToAction("Index");
        //}
    }
}
