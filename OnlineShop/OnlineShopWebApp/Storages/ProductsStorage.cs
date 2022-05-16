using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Storages
{
    public class ProductsStorage : IProductsStorage
    {
        private const string fileName = @"Models\Products.json";

        private List<Product> products;

        public ProductsStorage()
        {
            products = GetFromFile();
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGet(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int productId)
        {
            products.RemoveAll(product => product.Id == productId);
            UpdateFile();
        }

        public void Edit(Product newProduct)
        {
            var product = products.FirstOrDefault(x => x.Id == newProduct.Id);
            product.Name = newProduct.Name;
            product.Cost = newProduct.Cost;
            product.Description = newProduct.Description;

            UpdateFile();
        }

        public void Add(Product product)
        {
            products.Add(product);

            UpdateFile();
        }

        private List<Product> GetFromFile()
        {
            if (!File.Exists(fileName))
            {
                CreateFileWithDefaultProducts();
            }

            var reader = new StreamReader(fileName);
            var data = reader.ReadToEnd();
            reader.Close();

            return JsonConvert.DeserializeObject<List<Product>>(data);
        }

        private void CreateFileWithDefaultProducts()
        {
            products = new List<Product>()
            {
                new Product(0,"Составление документов, исков в суд", 5000, "Составление и оформление документов для подачи в суд", "/images/court.jpg"),
                new Product(1,"Составление документов для регистрации/банкротства ЮЛ", 4000, "Составление документов для регистрации/банкротства ЮЛ","/images/bankruptcy.jpg"),
                new Product(2,"Сопровождение и ведение гражданского дела в суде", 6000, "Сопровождение и ведение гражданского дела в суде","/images/civil_case.jpg"),
                new Product(3,"Консультация по вопросам", 3000, "Консультация по вопросам","/images/law_consultation.jpg"),
                new Product(4,"Анализ документов и договоров", 3000, "Правовая экспертиза документов и договоров","/images/examination_documents.jpg"),
            };
            UpdateFile();
        }

        private void UpdateFile()
        {
            var serializedData = JsonConvert.SerializeObject(products, Formatting.Indented);

            var writer = new StreamWriter(fileName, false, Encoding.UTF8);
            writer.WriteLine(serializedData);
            writer.Close();
        }
    }
}
