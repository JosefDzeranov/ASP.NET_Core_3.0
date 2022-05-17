using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ProductsRepositoryDb : IProductsRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public ProductsRepositoryDb(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        //public List<Product> products = new List<Product>()
        //{
        //    new Product("Teapot", 10, "Discription", "/images/item1.png"),
        //    new Product("Tea mug", 20, "Discription", "/images/item2.png"),
        //    new Product("Dish", 30, "Discription", "/images/item3.png"),
        //    new Product("Mug", 40, "Discription", "/images/item4.png"),
        //    new Product("Coffee mug", 50, "Discription", "/images/item5.png"),
        //    new Product("Bowl", 60, "Discription", "/images/item6.png"),
        //};

        public List<Product> GetAll()
        {
            return dataBaseContext.Products.ToList();
        }

        public Product TryGetById(Guid id)
        {
            return dataBaseContext.Products.FirstOrDefault(product => product.Id == id);
        }

        public void Add(Product product)
        {
            product.ImagePath = "/images/item1.png";
            dataBaseContext.Products.Add(product);
            dataBaseContext.SaveChanges();
        }

        public void Update(Product product)
        {
            var existingProduct = dataBaseContext.Products.FirstOrDefault(x => x.Id == product.Id);
            if (existingProduct==null)
            {
                return;
            }

            existingProduct.Name = product.Name;
            existingProduct.Cost = product.Cost;
            existingProduct.Description = product.Description;
            dataBaseContext.SaveChanges();
        }

        //public void Delete(Guid productId)
        //{
        //    dataBaseContext.Products.Remove(productId);
        //}
    }
}
