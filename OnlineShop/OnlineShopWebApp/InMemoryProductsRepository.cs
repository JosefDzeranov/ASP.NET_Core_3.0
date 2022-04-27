using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product
            { Name = "Оно",
              Cost = 450,
              Description = "Автор: Стивен Кинг Жанр: мистика, ужасы",
              Pages = 1025,
            },
            new Product
            { Name = "Мрачный жнец",
              Cost = 350,
              Description = "Автор: Терри Пратчетт Жанр: фэнтези",
              Pages = 356
            },
            new Product
            { Name = "Странник по звездам",
              Cost = 300,
              Description = "Автор: Джек Лондон Жанр: роман",
              Pages = 332
            },
            new Product
            { Name = "Крутые наследнички",
              Cost = 350,
              Description = "Автор: Дарья Донцова Жанр: детектив",
              Pages = 425
            },
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

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Edit(Product newProduct)
        {
            var product = products.FirstOrDefault(x => x.Id == newProduct.Id);
            product.Name = newProduct.Name;
            product.Cost = newProduct.Cost;
            product.Description = newProduct.Description;
            product.Pages = newProduct.Pages;
        }
        public void Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            products.Remove(product);
        }

        public List<Product> TryGetByName(string name)
        {
            List<Product> findProducts = new List<Product>();
            {
                foreach (var product in products)
                {
                    if (product.Name.ToLower().Contains(name.ToLower()))
                    {
                        findProducts.Add(product);
                    }
                }
            }
            return findProducts;
        }
    }
}

