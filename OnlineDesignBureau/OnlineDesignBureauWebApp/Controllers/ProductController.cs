using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineDesignBureauWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductCatalog productCatalog;
        public ProductController()
        {
            productCatalog = new ProductCatalog();
        }
        public string Index(string id)
        {
            if (int.TryParse(id, out int idToInt))
            {
                return productCatalog.GetId(idToInt);
            }
            return "Введенный id не является натуральным числом";
        }
        public string Save()
        {
            productCatalog.WriteToJson(productCatalog.GetProducts(), "projects_for_sale");
            return "Данные продуктов сохранены";
        }
        public string ReadFile()
        {
            productCatalog.ReadToJson("projects_for_sale");
            var result = "";
            foreach (var product in productCatalog.GetProducts())
            {
                result += product + "\n\n";
            }
            return result;
        }
        public string AddProduct(string name, decimal cost, string description)
        {
            productCatalog.CreateNewProduct(name, cost, description = $"Описание {name}");
            var result = productCatalog.GetProducts()[productCatalog.GetProducts().Count-1];
            return $"Добавленны новые продукты\n\n {result}";
        }

    }
}
