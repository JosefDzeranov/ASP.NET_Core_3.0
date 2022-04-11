using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace OnlineShopWebApp.Models
{
    public class ProductsStorage
    {
        public ProductsStorage productsStorage
        { 
            get;  
        }

        public ProductsStorage(ProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        private readonly List<Product> products = new List<Product>()
        {
            new Product(0,"Составление документов, исков в суд", 5000, "Составление и оформление документов для подачи в суд", "/images/court.jpg"),
            new Product(1,"Составление документов для регистрации/банкротства ЮЛ", 4000, "Составление документов для регистрации/банкротства ЮЛ","/images/bankruptcy.jpg"),
            new Product(2,"Сопровождение и ведение гражданского дела в суде", 6000, "Сопровождение и ведение гражданского дела в суде","/images/civil_case.jpg"),
            new Product(3,"Консультация по вопросам", 3000, "Консультация по вопросам","/images/law_consultation.jpg"),
            new Product(4,"Анализ документов и договоров", 3000, "Правовая экспертиза документов и договоров","/images/examination_documents.jpg"),
        };

        public List<Product> GetAll()
        {
            string currentFile = @"Models\Products.json";

            if (!File.Exists(currentFile))
            {
                string obj = JsonConvert.SerializeObject(products, Formatting.Indented);
                File.WriteAllText(@"Models\Products.json", obj);
            }
            List<Product> productsJson;

            try
            {
                productsJson = DeserializeJsonProducts();
            }
            catch (Exception)
            {
                return null;
            }

            return productsJson;
        }

        public Product TryGetProduct (int id)
        {
            List<Product> productsJson;

            try
            {
                productsJson = DeserializeJsonProducts();
            }
            catch (Exception) 
            { 
                return null; 
            }

            return productsJson.FirstOrDefault(x => x.Id == id);
        }

        public List<Product> DeserializeJsonProducts()
        {
            string currentFile = @"Models\Products.json";

            var strFromReq = new StreamReader(currentFile).ReadToEnd();

            List<Product> productsJson = JsonConvert.DeserializeObject<List<Product>>(strFromReq);

            return productsJson;
        }

    }
}
