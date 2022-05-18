using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        //private List<Product> products = new List<Product>()
        //{
        //    new Product
        //    { Name = "Оно",
        //      Cost = 450,
        //      Description = "Автор: Стивен Кинг Жанр: мистика, ужасы",
        //      Pages = 1025,
        //    },
        //    new Product
        //    { Name = "Мрачный жнец",
        //      Cost = 350,
        //      Description = "Автор: Терри Пратчетт Жанр: фэнтези",
        //      Pages = 356
        //    },
        //    new Product
        //    { Name = "Странник по звездам",
        //      Cost = 300,
        //      Description = "Автор: Джек Лондон Жанр: роман",
        //      Pages = 332
        //    },
        //    new Product
        //    { Name = "Крутые наследнички",
        //      Cost = 350,
        //      Description = "Автор: Дарья Донцова Жанр: детектив",
        //      Pages = 425
        //    },
        //};
        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }

        public Product TryGetById(Guid id)
        {
            return databaseContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void Edit(Product newProduct)
        {
            var product = databaseContext.Products.FirstOrDefault(x => x.Id == newProduct.Id);
            product.Name = newProduct.Name;
            product.Cost = newProduct.Cost;
            product.Description = newProduct.Description;
            product.Pages = newProduct.Pages;
            databaseContext.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var product = databaseContext.Products.FirstOrDefault(x => x.Id == id);
            databaseContext.Products.Remove(product);
        }

        public List<Product> TryGetByName(string name)
        {
            List<Product> findProducts = new List<Product>();
            {
                foreach (var product in databaseContext.Products)
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

