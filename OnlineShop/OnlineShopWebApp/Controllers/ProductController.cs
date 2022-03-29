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
        List<ProductList> productLists;
        public ProductController()
        {
            productLists = new List<ProductList>
             {
                new ProductList { Id = 1, Name= "Дебетовая карта №1", Cost=100, Description = "Молодежная карта. Для тех, кому от 14 лет до 21 года" },
                new ProductList { Id = 2, Name= "Дебетовая карта №2", Cost=150, Description = "Золотая карта. Бесплатное обслуживание с подпиской, также по подписке процент на остаток" },
                new ProductList { Id = 3, Name= "Кредитная карта №1", Cost=200, Description = "Процетная ставка годовых 20% на покупки, платежи, снятие наличных и переводы" },
            };
        }
        public string Index(int id)
        {
            var s = string.Empty;
            foreach (var product in productLists)
            {
                if (id == product.Id)
                {
                    s = $"{product.Id}\n{product.Name}\n{product.Cost}\n{product.Description}\n\n";
                    break;
                }
            }
            return s;
        }
    }
}
