using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductReposititory productReposititory;

        public ProductController()
        {
            productReposititory = new ProductReposititory();
        }
         
        public string Index(int id)
        {
            var product = productReposititory.TryGetById(id);
            if (product == null)
            {
                return $"Продукта с id:{id} не существует.";
            }
            return $"{product}\n{product.Description}";
        }
    }
}
