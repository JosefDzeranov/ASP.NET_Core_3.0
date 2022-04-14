using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class ProductsRepozitory
    {
        private List<Product> products = new List<Product>()
        {
            new Product("Оно", 450, "Автор: Стивен Кинг Жанр: мистика, ужасы"),
            new Product("Мрачный жнец", 350, "Автор: Терри Пратчетт Жанр: фэнтези"),
            new Product("Странник по звездам", 300, "Автор: Джек Лондон Жанр: роман"),
            new Product("Крутые наследнички", 350, "Автор: Дарья Донцова Жанр: детектив"),
        };
        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                    return product;
            }
            return null;
        }
    }
}
