﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        public List<Product> products = new List<Product>()
        {
            new Product("Оно", 450, "Автор: Стивен Кинг Жанр: мистика, ужасы", 1025),
            new Product("Мрачный жнец", 350, "Автор: Терри Пратчетт Жанр: фэнтези", 356),
            new Product("Странник по звездам", 300, "Автор: Джек Лондон Жанр: роман", 332),
            new Product("Крутые наследнички", 350, "Автор: Дарья Донцова Жанр: детектив", 425),
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
        public void Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            products.Remove(product);
        }

        public void Add(Product product)
        {
            products.Add(product);
        }
    }
}

