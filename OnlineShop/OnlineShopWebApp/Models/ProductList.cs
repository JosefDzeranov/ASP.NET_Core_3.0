using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class ProductList
    {
        private static List<Product> productLists = new List<Product>
             {
                new Product (1, "Дебетовая карта №1", 100, "Молодежная карта. Для тех, кому от 14 лет до 21 года" ),
                new Product (2, "Дебетовая карта №2", 150, "Золотая карта. Бесплатное обслуживание с подпиской, также по подписке процент на остаток" ),
                new Product (3, "Кредитная карта №1", 200, "Процетная ставка годовых 20% на покупки, платежи, снятие наличных и переводы" )
            };
        public static string Print()
        {
            var s = string.Empty;
            foreach (var product in productLists)
            {
                s += $"{product.Id}\n{product.Cost}\n{product.Name}\n\n";
            }
            return s;
        }
    }
}
