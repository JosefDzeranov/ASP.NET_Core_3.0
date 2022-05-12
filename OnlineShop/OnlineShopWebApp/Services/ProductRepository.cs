using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>()
        {
           new Product()
           {
               Name = "Незнайка на луне",
               Cost = 345.6m,
               Description = "Описание товара",
               ImgPath ="/images/book.png"
           },
           new Product()
           {
               Name = "Что делать?",
               Cost = 556.5m,
               Description = "Описание товара",
               ImgPath ="/images/book.png"
           },
           new Product()
           {
               Name = "Одисея капитана Блада",
               Cost = 1360.4m,
               Description = "Описание товара",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Война и мир",
               Cost = 790.6m,
               Description = "Описание товара",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Овод",
               Cost = 860.45m,
               Description = "Описание товара",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Капитанская дочка",
               Cost = 340.50m,
               Description = "Описание товара",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Преступление и наказание",
               Cost = 570.00m,
               Description = "Описание товара",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Тихий Дон",
               Cost =1200.00m,
               Description = "Описание товара",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Отцы и дети",
               Cost = 459.99m,
               Description = "Описание товара",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Богач, бедняк",
               Cost = 1100.85m,
               Description = "Описание товара",
               ImgPath ="/images/book.png"
           },

        };


        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public void Delete(Product product)
        {
            products.Remove(product);
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Update(Product product)
        {
            var oldProduct = TryGetById(product.Id);
            products.Remove(oldProduct);
            products.Add(product);
        }
    }
}
