using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ProductsDbStorage : IProductsStorage
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);

            databaseContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            //if (!File.Exists(FilePath))
            //{
            //    products.Add(new Product(0, "Составление документов, исков в суд", 5000, "Составление и оформление документов для подачи в суд", "/images/court.jpg"));
            //    products.Add(new Product(1, "Составление документов для регистрации/банкротства ЮЛ", 4000, "Составление документов для регистрации/банкротства ЮЛ", "/images/bankruptcy.jpg"));
            //    products.Add(new Product(2, "Сопровождение и ведение гражданского дела в суде", 6000, "Сопровождение и ведение гражданского дела в суде", "/images/civil_case.jpg"));
            //    products.Add(new Product(3, "Консультация по вопросам", 3000, "Консультация по вопросам", "/images/law_consultation.jpg"));
            //    products.Add(new Product(4, "Анализ документов и договоров", 3000, "Правовая экспертиза документов и договоров", "/images/examination_documents.jpg"));

            //    return products;
            //}
            return databaseContext.Products.ToList();
        }

        public Product TryGetProduct(Guid id)
        {
            return databaseContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void SaveEditedProduct(Product newProduct)
        {
            var existingProduct = databaseContext.Products.FirstOrDefault(x => x.Id == newProduct.Id);

            if (existingProduct == null)
            {
                return;
            }

            existingProduct.ImagePath = newProduct.ImagePath;
            existingProduct.Name = newProduct.Name;
            existingProduct.Cost = newProduct.Cost;
            existingProduct.Description = newProduct.Description;

            databaseContext.SaveChanges();
        }

        public void Delete(Guid productId)
        {
            var product = databaseContext.Products.FirstOrDefault(x => x.Id == productId);

            databaseContext.Products.Remove(product);
            
            databaseContext.SaveChanges();
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            var products = databaseContext.Products.Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return products;
        }
    }
}
