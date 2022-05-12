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
               Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do" +
               " eiusmod tempor incididunt ut labore et dolore magna aliqua." +
               "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi" +
               " ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit" +
               " in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur" +
               " sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
               ImgPath ="/images/book.png"
           },
           new Product()
           {
               Name = "Что делать?",
               Cost = 556.5m,
               Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do" +
               " eiusmod tempor incididunt ut labore et dolore magna aliqua." +
               "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi" +
               " ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit" +
               " in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur" +
               " sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
               ImgPath ="/images/book.png"
           },
           new Product()
           {
               Name = "Одисея капитана Блада",
               Cost = 1360.4m,
               Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do" +
               " eiusmod tempor incididunt ut labore et dolore magna aliqua." +
               "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi" +
               " ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit" +
               " in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur" +
               " sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Война и мир",
               Cost = 790.6m,
               Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do" +
               " eiusmod tempor incididunt ut labore et dolore magna aliqua." +
               "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi" +
               " ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit" +
               " in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur" +
               " sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Овод",
               Cost = 860.45m,
               Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do" +
               " eiusmod tempor incididunt ut labore et dolore magna aliqua." +
               "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi" +
               " ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit" +
               " in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur" +
               " sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Капитанская дочка",
               Cost = 340.50m,
               Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do" +
               " eiusmod tempor incididunt ut labore et dolore magna aliqua." +
               "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi" +
               " ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit" +
               " in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur" +
               " sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Преступление и наказание",
               Cost = 570.00m,
               Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do" +
               " eiusmod tempor incididunt ut labore et dolore magna aliqua." +
               "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi" +
               " ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit" +
               " in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur" +
               " sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Тихий Дон",
               Cost =1200.00m,
               Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do" +
               " eiusmod tempor incididunt ut labore et dolore magna aliqua." +
               "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi" +
               " ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit" +
               " in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur" +
               " sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Отцы и дети",
               Cost = 459.99m,
               Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do" +
               " eiusmod tempor incididunt ut labore et dolore magna aliqua." +
               "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi" +
               " ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit" +
               " in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur" +
               " sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
               ImgPath ="/images/book.png"
           },
            new Product()
           {
               Name = "Богач, бедняк",
               Cost = 1100.85m,
               Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do" +
               " eiusmod tempor incididunt ut labore et dolore magna aliqua." +
               "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi" +
               " ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit" +
               " in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur" +
               " sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
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
