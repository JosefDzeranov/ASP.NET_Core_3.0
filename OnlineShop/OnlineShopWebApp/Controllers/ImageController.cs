using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ImageController : Controller
    {

        private readonly IProductsRepository productReposititory;

        public ImageController(IProductsRepository productReposititory)
        {
            this.productReposititory = productReposititory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id, Image image)
        {
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileNameWithoutExtension(image.Name);
                var extension = Path.GetExtension(image.Name);
                image.Name = "item" + productReposititory.TryGetById(id) + extension;
                var path = Path.Combine("/Image/", fileName);
                var fileStream = new FileStream(path, FileMode.Create);

                return RedirectToAction("Index");
            }
            return View(image);
        }

        [HttpPost]
        public IActionResult Delete(int id, Image image)
        {
            var imagePath = Path.Combine("/Image/", image.Name); 
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            
            return RedirectToAction("Index");
        }




    }
}
