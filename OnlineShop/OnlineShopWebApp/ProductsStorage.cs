using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OnlineShopWebApp.Models
{
    public class ProductsStorage
    {

        private static readonly List<Product> products = new List<Product>()
        {
            new Product("Составление документов, исков в суд", 5000, "Составление и оформление документов для подачи в суд"),
            new Product("Составление документов для регистрации/банкротства ЮЛ", 4000, "Составление документов для регистрации/банкротства ЮЛ"),
            new Product("Сопровождение и ведение гражданского дела в суде", 6000, "Сопровождение и ведение гражданского дела в суде"),
            new Product("Консультация по вопросам", 3000, "Консультация по вопросам"),
            new Product("Анализ документов и договоров", 3000, "Правовая экспертиза документов и договоров"),
        };

        public static List<ProductJson> GetAll()
        {
            string currentFile = @"Models\Products.json";
            if (File.Exists(currentFile))
                File.Delete(currentFile);

            if (!File.Exists(currentFile))
            {
                string json3 = JsonConvert.SerializeObject(products, Formatting.Indented);
                File.WriteAllText(@"Models\Products.json", json3);
            }
            List<ProductJson> productsJson;

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

        public static ProductJson TryGetProduct (int id)
        {
            List<ProductJson> productsJson;

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

        public static List<ProductJson> DeserializeJsonProducts()
        {
            string currentFile = @"Models\Products.json";

            var strFromReq = new StreamReader(currentFile).ReadToEnd();

            List<ProductJson> productsJson = JsonConvert.DeserializeObject<List<ProductJson>>(strFromReq);

            return productsJson;
        }

    }
}
