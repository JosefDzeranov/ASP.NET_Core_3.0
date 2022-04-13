﻿using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class ProductsStorage : IProductsStorage
    {
        private List<Product> products = new List<Product>
             {
                new Product ("Дебетовая карта №1", 100, "Молодежная карта. Для тех, кому от 14 лет до 21 года" ),
                new Product ("Дебетовая карта №2", 150, "Золотая карта. Бесплатное обслуживание с подпиской, также по подписке процент на остаток" ),
                new Product ("Кредитная карта №1", 200, "Процетная ставка годовых 20% на покупки, платежи, снятие наличных и переводы" )
            };
        public List<Product> GetAllProducts()
        {
            return products;
        }
        public Product TryGetProduct(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }
    }
}
