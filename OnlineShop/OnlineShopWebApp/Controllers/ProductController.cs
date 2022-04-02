using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public string Index(int id)
        {
            var requestedProduct = ProductsStorage.TryGetProduct(id);
            if (requestedProduct == null)
            {
                return "Такого товара нет в списке, введите товар с номером от 1 до 3 включительно";
            }
            return requestedProduct + $"\n{requestedProduct.Description}";
        }
    }
}
