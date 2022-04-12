using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class ProductRepozitory
    {
        private static List<Product> products = new List<Product>()
        {
            new Product("Оно", 450, "Автор: Стивен Кинг, жанр: мистика, ужасы"),
            new Product("Мрачный жнец", 350, "Автор: Терри Пратчетт, жанр: фэнтези"),
            new Product("Странник по звездам", 300, "Автор: Джек Лондон, жанр: роман"),
            new Product("Крутые наследнички", 350, "Автор: Дарья Донцова, жанр: детектив"),
        };
        public List<Product> GetAll()
        {
            return products;
        }
    }
}
