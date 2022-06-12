using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ProductManagerDB : IProductManager
    {
        private readonly DataBaseContext dataBaseContext;
        public ProductManagerDB(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        //public List<Product> ProductList { get; set; } = new List<Product>
        //{

        //       new Product(1, "Cheeseburger", 150, "бургер с говяжьей котлетой и сыром"),
        //       new Product(2, "Hamburger", 120, "бургер с говяжьей котлетой"),
        //       new Product(3, "Bigburger", 200, "бургер с двойной говяжьей котлетой")

        //};
        
        public void AddProduct(Product product)
        {
            dataBaseContext.Products.Add(product);
            dataBaseContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            if (dataBaseContext.Products.Count() == 0)
            {
                dataBaseContext.Products.Add(new Product
                {
                    Name = "Cheeseburger",
                    Cost = 5,
                    Description = "Just a cheeseburger"
                });
                dataBaseContext.Products.Add(new Product
                {
                    Name = "Hamburger",
                    Cost = 3,
                    Description = "Just a hamburger"
                });
                dataBaseContext.Products.Add(new Product
                {
                    Name = "Bigburger",
                    Cost = 10,
                    Description = "the biggest burger"
                });

                dataBaseContext.SaveChanges();


            }
            return dataBaseContext.Products.ToList();
        }
      

        public Product TryGetById(Guid id)
        {
            return dataBaseContext.Products.FirstOrDefault(product => product.Id == id);
        }

        public void EditProduct(Product editedProduct)
        {
            foreach (var product in dataBaseContext.Products)
            {
                if (product.Id == editedProduct.Id)
                {
                    product.Name = editedProduct.Name;
                    product.Description = editedProduct.Description;
                    product.Cost = editedProduct.Cost;
                }
            }
            dataBaseContext.SaveChanges();
        }

    }
}
